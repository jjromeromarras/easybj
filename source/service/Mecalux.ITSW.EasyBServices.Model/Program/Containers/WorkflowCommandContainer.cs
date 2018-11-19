using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyBServices.Model
{
    public class WorkflowCommandContainer: BaseEntity
    {
        #region Fields
        private List<WorkflowCommand> workflowCommands;
        #endregion

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public WorkflowCommandContainer()
            : base()
        {
            workflowCommands = new List<WorkflowCommand>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<WorkflowCommand> WorkflowCommandsInternal
        {
            get
            {
                workflowCommands.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return workflowCommands;
            }
            set { workflowCommands = new List<WorkflowCommand>(value); }
        }
        #endregion

        #region Methods

        public void Add(WorkflowCommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowCommand can not be null");

                this.workflowCommands.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkflowCommand exception in add operation: " + ex.Message);
            }


        }

        public void Remove(WorkflowCommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowCommand can not be null");

                WorkflowCommand obj = this.workflowCommands.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.workflowCommands.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkflowCommand exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(WorkflowCommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowCommand can not be null");

                WorkflowCommand obj = this.workflowCommands.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "WorkflowCommand doesn't find");
                }
                else
                {
                    this.workflowCommands.Remove(obj);
                    this.workflowCommands.Add(element);
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
