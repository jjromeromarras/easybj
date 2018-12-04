using System;
using System.Collections.Generic;

namespace Mecalux.ITSW.EasyB.Model
{
    public class WorkflowQueryCommandContainer: BaseEntity
    {
        #region Fields
        private List<WorkflowQueryCommand> workflowQueryCommands;
        #endregion

        #region Constructors

        /// <summary>
        /// Default class constructor
        /// </summary>
        public WorkflowQueryCommandContainer()
            : base()
        {
            workflowQueryCommands = new List<WorkflowQueryCommand>();
        }

        #endregion Constructors

        #region Properties
        public IEnumerable<WorkflowQueryCommand> WorkflowQueryCommandsInternal
        {
            get
            {
                workflowQueryCommands.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                return workflowQueryCommands;
            }
            set { workflowQueryCommands = new List<WorkflowQueryCommand>(value); }
        }
        #endregion

        #region Methods

        public void Add(WorkflowQueryCommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowQueryCommand can not be null");

                this.workflowQueryCommands.Add(element);
                // TODO BASE DE DATOS
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkflowQueryCommand exception in add operation: " + ex.Message);
            }


        }

        public void Remove(WorkflowQueryCommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowQueryCommand can not be null");

                WorkflowQueryCommand obj = this.workflowQueryCommands.Find(p => p.Guid == element.Guid);
                if (obj != null)
                {
                    this.workflowQueryCommands.Remove(obj);
                    // TODO BASE DE DATOS
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("element", "WorkflowQueryCommand exception in remove operation: " + ex.Message);
            }
        }

        public void Edit(WorkflowQueryCommand element)
        {
            try
            {
                if (element == null)
                    throw new ArgumentNullException("element", "WorkflowQueryCommand can not be null");

                WorkflowQueryCommand obj = this.workflowQueryCommands.Find(p => p.Guid == element.Guid);
                if (obj == null)
                {
                    throw new ArgumentNullException("element", "WorkflowQueryCommand doesn't find");
                }
                else
                {
                    this.workflowQueryCommands.Remove(obj);
                    this.workflowQueryCommands.Add(element);
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
