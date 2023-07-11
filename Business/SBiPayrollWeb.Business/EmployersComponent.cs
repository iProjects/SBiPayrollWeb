//====================================================================================================
// Base code generated with Motion: BC Gen (Build 2.2.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 06/12/2014 08:33:44 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SBiPayrollWeb.Entities;
using SBiPayrollWeb.Data;


namespace SBiPayrollWeb.Business
{
    /// <summary>
    /// Employers business component.
    /// </summary>
    public partial class EmployersComponent
    {
        /// <summary>
        /// GetAllEmployers business method. 
        /// </summary>
        /// <returns>Returns a List<Employer> object.</returns>
        public List<Employer> GetAllEmployers()
        {
            List<Employer> result = default(List<Employer>);

            // Data access component declarations.
            EmployerDAC employerDAC = new EmployerDAC();

            // Step 1 - Calling Select on EmployerDAC.
            result = employerDAC.Select();
            return result;

        }

        /// <summary>
        /// GetEmployer business method. 
        /// </summary>
        /// <param name="id">A id value.</param>
        /// <returns>Returns a Employer object.</returns>
        public Employer GetEmployer(int id)
        {
            Employer result = default(Employer);

            // Data access component declarations.
            EmployerDAC employerDAC = new EmployerDAC();

            // Step 1 - Calling SelectById on EmployerDAC.
            result = employerDAC.SelectById(id);
            return result;

        }

        /// <summary>
        /// CreateEmployer business method. 
        /// </summary>
        /// <param name="employer">A employer value.</param>
        /// <returns>Returns a Employer object.</returns>
        public Employer CreateEmployer(Employer employer)
        {
            Employer result = default(Employer);

            // Data access component declarations.
            EmployerDAC employerDAC = new EmployerDAC();

            // Step 1 - Calling Create on EmployerDAC.
            result = employerDAC.Create(employer);
            return result;

        }

        /// <summary>
        /// DeleteEmployer business method. 
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteEmployer(int id)
        {
            // Data access component declarations.
            EmployerDAC employerDAC = new EmployerDAC();

            // Step 1 - Calling DeleteById on EmployerDAC.
            employerDAC.DeleteById(id);

        }

        /// <summary>
        /// UpdateEmployer business method. 
        /// </summary>
        /// <param name="employer">A employer value.</param>
        public void UpdateEmployer(Employer employer)
        {
            // Data access component declarations.
            EmployerDAC employerDAC = new EmployerDAC();

            // Step 1 - Calling UpdateById on EmployerDAC.
            employerDAC.UpdateById(employer);

        }
    }
}
