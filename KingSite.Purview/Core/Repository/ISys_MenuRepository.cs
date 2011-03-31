using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KingSite.Purview.Domain;

namespace KingSite.Purview.Core.Repository {

    /// <summary><c>ISys_MenuRepository</c> is the DAO interface for <see cref="SysMenu"/>.</summary>
    public partial interface ISys_MenuRepository {

        /// <summary>Returns the total count of objects.</summary>
        int GetCount();

        /// <summary>Finds a <see cref="Sys_Menu"/> instance by the primary key value.</summary>
        Sys_Menu Find(Int32 id);

        /// <summary>Finds all Sys_Menu instances.</summary>
        IList<Sys_Menu> FindAll();

        /// <summary>Inserts a new Sys_Menu instance into underlying database table.</summary>
        void Insert(Sys_Menu obj);

        /// <summary>Update the underlying database record of a Sys_Menu instance.</summary>
        void Update(Sys_Menu obj);

        /// <summary>Delete the underlying database record of a Sys_Menu instance.</summary>
        void Delete(Sys_Menu obj);

        IList<Sys_Menu> FindByIds(string ids);

    }

}
