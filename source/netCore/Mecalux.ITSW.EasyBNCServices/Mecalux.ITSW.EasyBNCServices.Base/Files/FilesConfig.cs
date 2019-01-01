using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.ITSW.EasyBCoreServices.Base.Files
{
    public static class FilesConfig
    {
        #region Fields

        private const string PatternFiles = " (*.{0}) | *.{0}";

        #endregion Fields

        #region Properties

        public static string AllDeployPackageFilesPatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "All package files" + PatternFiles, string.Join("; *.", DeployPackageExtensionFile, DeployPackageConfigExtensionFile)); }
        }

        /// <summary>
        /// Extensión del fichero de de exportación e importación de ApplicationTagContainer
        /// </summary>
        public static string ApplicationTagContainerExtensionFile
        {
            get { return "EasyB"; }
        }

        public static string ApplicationTagContainerFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyB files" + PatternFiles, ApplicationTagContainerExtensionFile); }
        }

        /// <summary>
        /// Patrón para cargar ficheros de importación y exportación de ApplicationTagContainer
        /// </summary>
        public static string ApplicationTagContainerExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyBuilder file" + PatternFiles, ApplicationTagContainerExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero CSV
        /// </summary>
        public static string CsvExtensionFile
        {
            get { return "csv"; }
        }

        /// <summary>
        /// Patrón para cargar ficheros CSV
        /// </summary>
        public static string CsvPatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "CSV" + PatternFiles, CsvExtensionFile); }
        }

        public static string DeployPackageConfigExtensionFile
        {
            get { return "EasyBpckConfig"; }
        }

        public static string DeployPackageConfigExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Deploy package config files" + PatternFiles, DeployPackageConfigExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero del paquete de despliegue
        /// </summary>
        public static string DeployPackageExtensionFile
        {
            get { return "pck"; }
        }

        /// <summary>
        /// Patrón de cargar del fichero del paquete de despliegue
        /// </summary>
        public static string DeployPackageExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "PCK files" + PatternFiles, DeployPackageExtensionFile); }
        }

        public static string EasyBconfigTemplateExtensionFile
        {
            get { return "EasyBconfigTemplate"; }
        }

        public static string EasyBconfigTemplateExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyB config template" + PatternFiles, EasyBconfigTemplateExtensionFile); }
        }

        public static string EasyBPartialExtensionFile
        {
            get { return "EasyBpart"; }
        }

        public static string EasyBPartialPatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyB partial file" + PatternFiles, EasyBPartialExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero de de exportación e importación de una Entity
        /// </summary>
        public static string EntityExtensionFile
        {
            get { return "EasyBE"; }
        }

        /// <summary>
        /// Patrón para cargar ficheros de importación y exportación de una Entidad
        /// </summary>
        public static string EntityExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyBuilder file" + PatternFiles, EntityExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero RepX
        /// </summary>
        public static string RepXExtensionFile
        {
            get { return "repx"; }
        }

        /// <summary>
        /// Patrón para cargar ficheros RepX
        /// </summary>
        public static string RepXPatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Report files" + PatternFiles, RepXExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero ResX
        /// </summary>
        public static string ResXExtensionFile
        {
            get { return "resx"; }
        }

        /// <summary>
        /// Patrón para cargar ficheros ResX
        /// </summary>
        public static string ResXPatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Resource files" + PatternFiles, ResXExtensionFile); }
        }

        public static string TextExtensionFile
        {
            get { return "txt"; }
        }

        public static string TextPatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Text" + PatternFiles, TextExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero de de exportación e importación de View
        /// </summary>
        public static string ViewExtensionFile
        {
            get { return "EasyBV"; }
        }

        /// <summary>
        /// Patrón para cargar ficheros de importación y exportación de View
        /// </summary>
        public static string ViewExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyBuilder file" + PatternFiles, ViewExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero de de exportación e importación de WorkflowContainerTag
        /// </summary>
        public static string WorkflowContainerTagExtensionFile
        {
            get { return "EasyBW"; }
        }

        /// <summary>
        /// Patrón para cargar ficheros de importación y exportación de WorkflowContainerTag
        /// </summary>
        public static string WorkflowContainerTagExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyBuilder file" + PatternFiles, WorkflowContainerTagExtensionFile); }
        }

        public static string WorkflowQueryDataExtensionFile
        {
            get { return "EasyBQData"; }
        }

        public static string WorkflowQueryDataExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyBuilder file" + PatternFiles, WorkflowQueryDataExtensionFile); }
        }

        public static string WorkflowQueryExtensionFile
        {
            get { return "EasyBQ"; }
        }

        public static string WorkflowQueryExtensionFilePatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "EasyBuilder file" + PatternFiles, WorkflowQueryExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero XML
        /// </summary>
        public static string XmlExtensionFile
        {
            get { return "xml"; }
        }

        /// <summary>
        /// Patrón para cargar ficheros XML
        /// </summary>
        public static string XmlPatternFile
        {
            get { return string.Format(CultureInfo.InvariantCulture, "XML" + PatternFiles, XmlExtensionFile); }
        }

        /// <summary>
        /// Extensión del fichero Zip
        /// </summary>
        public static string ZipExtensionFile
        {
            get { return "zip"; }
        }

        #endregion Properties
    }
}
