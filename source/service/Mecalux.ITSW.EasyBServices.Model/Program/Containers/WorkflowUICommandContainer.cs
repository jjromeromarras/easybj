using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowUICommandContainer: BaseEntity
    {
        #region Fields
        private List<WorkflowUICommand> workflowuiCommands;
        #endregion

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public WorkflowUICommandContainer()
            : base()
        {
            workflowuiCommands = new List<WorkflowUICommand>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<WorkflowUICommand> WorkflowUICommandsInternal
        {
            get
            {
                workflowuiCommands.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return workflowuiCommands;
            }
            set { workflowuiCommands = new List<WorkflowUICommand>(value); }
        }
        #endregion

        #region Methods

        public void Add(WorkflowUICommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowUICommand can not be null");

                this.workflowuiCommands.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkflowUICommand exception in add operation: " + ex.Message);
            }


        }

        public void Remove(WorkflowUICommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowUICommand can not be null");

                WorkflowUICommand obj = this.workflowuiCommands.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.workflowuiCommands.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkflowUICommand exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(WorkflowUICommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowUICommand can not be null");

                WorkflowUICommand obj = this.workflowuiCommands.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "WorkflowUICommand doesn't find");
                }
                else
                {
                    this.workflowuiCommands.Remove(obj);
                    this.workflowuiCommands.Add(element);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "SecGroup exception in remove operation: " + ex.Message);
            }
        }
        #endregion
    }
}
