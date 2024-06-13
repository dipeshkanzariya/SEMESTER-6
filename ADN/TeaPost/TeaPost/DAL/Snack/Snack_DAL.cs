using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
using TeaPost.Areas.Snack.Models;

namespace TeaPost.DAL.Snack
{
    public class Snack_DAL : Snack_DALBase
    {

        #region PR_Snack_Filter

        public DataTable dbo_PR_Snack_Filter(SnackModel model)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(MyConnectionString);
                DbCommand cmd = sqlDb.GetStoredProcCommand("dbo.PR_Snack_Filter");
                sqlDb.AddInParameter(cmd, "@SnackName", SqlDbType.NVarChar, model.SnackName);
                sqlDb.AddInParameter(cmd, "@Price", SqlDbType.Decimal, model.Price);
                sqlDb.AddInParameter(cmd, "@Size", SqlDbType.Int, model.Size);

                DataTable dt = new DataTable();
                using(IDataReader dr = sqlDb.ExecuteReader(cmd))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}
