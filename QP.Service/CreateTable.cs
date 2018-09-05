using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QP.Cashier_Service
{
    public static class CreateTable
    {
        public static DataTable ReturnColuns(DataTable table, List<string> Clounms)
        {
            try
            {
                table = new DataTable();
                if (Clounms.Count >0)
                {
                    for (int i = 0; i < Clounms.Count; i++)
                    {
                        table.Columns.Add(Clounms[i], typeof(String));
                    }
                }
            }
            catch (Exception el){}
            return table;
        }

    }
}
