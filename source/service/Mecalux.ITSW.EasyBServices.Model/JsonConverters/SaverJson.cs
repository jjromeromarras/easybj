using Mecalux.ITSW.EasyBServices.Base.Files;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class SaverJson
    {
        #region Fields
        public const string FieldTypesFolder = "FieldTypes";
        public const string RecordsFolder = "Records";
        public const string ListsFolder = "Lists";
        public const string EntitiesFolder = "Entities";

        private List<string> pendingApplicationsInternal;

        private static List<JsonConverter> writeConverters;
        private static ITraceWriter traceWriter;
        private static List<JsonConverter> readConverters;
        public static readonly string ApplicationFileName = "Application." + FilesConfig.EasyBPartialExtensionFile;
        public static readonly string InlineSeparator = @"\r\n";
        public static readonly string MultiLineSeparator = Environment.NewLine + "#:";
        private static string[] dummyFilesInRepositoryFolders = new string[] { ".gitignore" };
        #endregion

        #region Constructors

        public SaverJson(IEnumerable<string> pendingApplications)
            : this()
        {
            pendingApplicationsInternal = new List<string>(pendingApplications);
        }

        public SaverJson()
        {
            pendingApplicationsInternal = new List<string>();
        }

        #endregion Constructors

        #region Properties
        public ITraceWriter Trace
        {
            get
            {
                if (traceWriter == null)
                {
                    System.Diagnostics.TraceLevel currentTraceLevel = System.Diagnostics.TraceLevel.Warning;
                    traceWriter = new MemoryTraceWriter()
                    {
                        LevelFilter = currentTraceLevel
                    };
                }
                return traceWriter;
            }
        }
        #endregion

        #region Export Methods 
        private List<JsonConverter> WriteConverters
        {
            get
            {
                if (writeConverters == null)
                {
                    writeConverters = new List<JsonConverter>
                    {
                        new FieldTypeJsonConverter(),
                        new RecordJsonConverter(),
                        new RecordListJsonConverter(),
                        new StringEnumConverter(),
                        new EntityJsonConverter()
                    };
                }
                return writeConverters;
            }
        }
        public JsonSerializerSettings BuildDefaultJsonSettings()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                TypeNameHandling = TypeNameHandling.All,
                TraceWriter = Trace
            };
            return jsonSerializerSettings;
        }
        public void SerializeObject(string destinationFileName, object serializationObject)
        {
            UTF8Encoding utf8WithoutBom = new System.Text.UTF8Encoding(false);
            using (StreamWriter writer = new StreamWriter(destinationFileName, false, utf8WithoutBom))
                try
                {
                    JsonConvert.DefaultSettings = BuildDefaultJsonSettings;
                    string json = JsonConvert.SerializeObject(serializationObject, Formatting.Indented, WriteConverters.ToArray());
                    json = json.Replace(InlineSeparator, MultiLineSeparator);
                    writer.Write(json);
                }
                catch (Exception ex)
                {
                    string trace = "Uninitilized trace";
                    try
                    {
                        lock (Trace)
                            trace = Trace.ToString();
                    }
                    catch { }
                    writer.Write(ex.Message);
                    writer.Write(trace);
                    //PendingSerializations.Add(new Tuple<string, object>(destinationFileName, serializationObject));
                }
        }

        public bool ExportApplicationTag(string path, ApplicationTag applicationtag)
        {
            try
            {
                if (applicationtag == null)
                    return false;
                else
                    ExportJsonToFolderApplication(applicationtag.Entity, path+ @"\"+applicationtag.Entity.Name);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ExportJsonToFolderApplication(Application application,  string combinedPath)
        {

            string lastFolderName = combinedPath.Split(Path.DirectorySeparatorChar).Last();
            Stopwatch totalWatch = Stopwatch.StartNew();
            CheckAndCreateFolder(combinedPath, false);
            BuildDefaultJsonSettings();
            //GuidReferenceResolver.ClearCachedReferences();
            //entity.ParentProgram.VersionIdResolver.InvalidateApplication(entity.Name);

            SerializeCollection(combinedPath, lastFolderName, application.FieldTypeContainer.FieldTypeListsInternal, FieldTypesFolder, "FieldTypes");
            SerializeCollection(combinedPath, lastFolderName, application.RecordContainer.RecordsInternal, RecordsFolder, "Records");
            SerializeCollection(combinedPath, lastFolderName, application.RecordListContainer.RecordListsInternal, ListsFolder, "Lists");
            SerializeCollection(combinedPath, lastFolderName, application.EntityContainer.EntityListsInternal, EntitiesFolder, "Entities");


            /*            using (ResultManager.Create($"Serialize 'Resources' file ({application.ResourceContainer} resources)"))
                            SerializeElement(combinedPath, ResourcesFileName, lastFolderName, "Resources", application.ResourceContainer);

                        using (ResultManager.Create($"Serialize 'Application' file"))
                            SerializeElement(combinedPath, ApplicationFileName, lastFolderName, "Application", entity);



                        using (ResultManager.Create($"Serialize {application.WorkflowContainer.ChildWorkflowCommandsLastUsablesLocal.Count} 'Commands' files"))
                            SerializeCollection(combinedPath, lastFolderName, application.WorkflowContainer.ChildWorkflowCommandsLastUsablesLocal, CommandsFolder, "Commands");

                        using (ResultManager.Create($"Serialize {application.WorkflowContainer.ChildWorkflowUICommandsLastUsablesLocal.Count} 'Dialogs' files"))
                            SerializeCollection(combinedPath, lastFolderName, application.WorkflowContainer.ChildWorkflowUICommandsLastUsablesLocal, DialogsFolder, "Dialogs");

                        using (ResultManager.Create($"Serialize {application.WorkflowContainer.ChildWorkflowQueryCommandsLastUsablesLocal.Count} 'Queries' files"))
                            SerializeCollection(combinedPath, lastFolderName, application.WorkflowContainer.ChildWorkflowQueryCommandsLastUsablesLocal, QueriesFolder, "Queries");

                        using (ResultManager.Create($"Serialize {application.EventContainer.ChildEventsLastUsablesLocal.Count} 'Events' files"))
                            SerializeCollection(combinedPath, lastFolderName, application.EventContainer.ChildEventsLastUsablesLocal, EventsFolder, "Events");

                        using (ResultManager.Create($"Serialize {application.WorkflowContainer.ChildWorkflowsLastUsablesLocal.Count} 'Workflows' files"))
                            SerializeCollection(combinedPath, lastFolderName, application.WorkflowContainer.ChildWorkflowsLastUsablesLocal, WorkflowsFolder, "Workflows");

                        using (ResultManager.Create("Clear subscriptions of workflows"))
                            foreach (var wf in application.WorkflowContainer.ChildWorkflowsLastUsablesLocal)
                                wf.ClearSubscriptionsInternal();

                        using (ResultManager.Create($"Serialize {application.SubscriptionContainer.ChildSubscriptionsLastUsablesLocal.Count} 'Subscriptions' files"))
                            SerializeCollection(combinedPath, lastFolderName, application.SubscriptionContainer.ChildSubscriptionsLastUsablesLocal, SubscriptionsFolder, "Subscriptions");

                        using (ResultManager.Create($"Serialize {application.ReportContainer.ReportsLocal.Count()} 'Reports' files"))
                            SerializeCollection(combinedPath, lastFolderName, application.ReportContainer.ReportsLocal, ReportsFolder, "Reports");


                        using (ResultManager.Create($"Serialize 'Relationships' file ({application.RelationshipContainer.Relationships.Count} relationships)"))
                            SerializeElement(combinedPath, RelationshipsFileName, lastFolderName, "Relationships", application.RelationshipContainer);

                        var views = application.ViewContainer.ChildViewsLastUsablesLocal.Where(v => v.DependsOtherView == null).ToList();
                        using (ResultManager.Create($"Serialize {views.Count} 'Views' files"))
                            SerializeCollection(combinedPath, lastFolderName, views, ViewsFolder, "Views");

                        using (ResultManager.Create("Show dialog of operation result"))
                        {
                            string message = Context.Localize("ApplicationExportProcess");
                            var st = Stopwatch.StartNew();
                            long size = DirectorySize(new DirectoryInfo(combinedPath));
                            var calElapsed = st.ElapsedMilliseconds;
                            Log.Info("ExportJsonToFolder of {0} was {1:N}ms and size was {2:N}; calculated in {3}ms.", lastFolderName, totalWatch.ElapsedMilliseconds, size.ToFileSize(), calElapsed);
                            Context.SetWaitingCustom(string.Format(CultureInfo.CurrentCulture, "{0} ({1})", message, size.ToFileSize()));
                        }*/
        }


        private void SerializeCollection(string combinedPath, string lastFolderName, IEnumerable<NameEntity> collection, string directory, string type)
        {
            string path = Path.Combine(combinedPath, directory);
            CheckAndCreateFolder(path, true);
            Stopwatch currentWatch = Stopwatch.StartNew();
            int counter = 0;
            string localizedType = type;
            int total = collection.Count();
            Parallel.ForEach(collection.OrderBy(x => x.Name), (element) =>
            {
                counter++;
                SerializeObject(Path.Combine(path, HelperJsonConverter.GetReferenceInternal(element)), element);
            });

        }
        #endregion

        #region Import Methods
        public bool ExistsApplicationInPath(string path)
        {
            bool result = File.Exists(Path.Combine(path, ApplicationFileName));

            return result;
        }
       
        public JsonSerializerSettings BuildImportJsonSettings()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ObjectCreationHandling = ObjectCreationHandling.Reuse,
                TypeNameHandling = TypeNameHandling.All,                
                TraceWriter = Trace
            };
            return jsonSerializerSettings;
        }

        private int ImportJsonFromFolderInternal<T>(string combinedPath, ApplicationTagContainer entity, string specificFolder, string typeName) where T : class, IBaseEntity
        {
            string elementsPath = Path.Combine(combinedPath, specificFolder);
            int elementsTotal = 0;
            if (Directory.Exists(elementsPath))
            {
                IEnumerable<string> elements = Directory.GetFiles(elementsPath, Path.ChangeExtension("*", FilesConfig.EasyBPartialExtensionFile));
                int elementsCount = 0;
                elementsTotal = elements.Count();
                List<string> elementsWithError = new List<string>();
                foreach (string element in elements)
                {
                    elementsCount++;
                    T elementEntity = ImportPart<T>(element);
                    if (elementEntity == null)
                    {                    
                        elementsWithError.Add(element);
                    }
                }
                elementsCount = 0;
                elementsTotal = elementsWithError.Count();                
            }
            else
            {
               // Log.Warn($"{typeName} folder not found: {elementsPath}");
            }
            return elementsTotal;
        }

        public T ImportPart<T>(string pathName) where T : class
        {
            if (File.Exists(pathName))
                try
                {
                    string json = File.ReadAllText(pathName);
                    json = json.Replace(MultiLineSeparator, InlineSeparator);
                    JsonConvert.DefaultSettings = BuildImportJsonSettings;
                    T result = (T)JsonConvert.DeserializeObject(json, typeof(T), ReadConverters.ToArray());
                    return result;
                }
                catch (Exception ex)
                {
                   // Log.ErrorException("[Error] Error reading file '" + pathName + "':" + Trace.ToString(), ex);
                }
            return null;
        }

        private List<JsonConverter> ReadConverters
        {
            get
            {
                if (readConverters == null)
                {
                    readConverters = new List<JsonConverter>
                    {
                        new RecordListJsonConverter(),
                        new FieldTypeJsonConverter(),
                        new EntityJsonConverter(),
                        new RecordJsonConverter()

                        /*new ValidatorCreationConverter(),
                        new RelationshipCreationConverter(),
                        new WorkflowActivityCreationConverter(),
                        new WorkflowBasicCreationConverter(),
                        new PointConverter(),
                        new ResourceLanguageConverter(),
                        new EntityCreationConverter(),
                        new ResourceCreationConverter(),
                        new ViewCreationConverter(),
                        new ViewGroupCreationConverter(),
                        new ViewParameterCreationConverter(),
                        new WorkflowFormalParameterCreationConverter(),
                        new PropertyCreationConverter(),*/
                        //new SubscriptionSerializeConverter(),
                        //new WorkstationJobCreationConverter()
                    };
                }
                return readConverters;
            }
        }
        #endregion

        #region Aux Methods
        private void CheckAndCreateFolder(string folder, bool createDummyFiles)
        {
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            else
                foreach (string file in Directory.GetFiles(folder, Path.ChangeExtension("*", FilesConfig.EasyBPartialExtensionFile)))
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                        //Log.Error("Error deleting file: {0}", file);
                    }
            if (createDummyFiles)
                CreateDummyFiles(folder);
        }

        private void CreateDummyFiles(string folder)
        {
            foreach (string filename in dummyFilesInRepositoryFolders)
            {
                string file = Path.Combine(folder, filename);
                if (!File.Exists(file))
                    using (File.Open(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        File.SetLastWriteTimeUtc(file, DateTime.UtcNow);
                    }
            }
        }
        #endregion
    }
}
