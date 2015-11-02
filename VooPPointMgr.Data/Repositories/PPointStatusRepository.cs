using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using VooPPointMgr.Data;

namespace VooPPointMgr.Data
{
    public class PPointStatusRepository
    {
        public static tppointstatu[] GetAllPpointStatus()
        {
            using (vooEntities context = new vooEntities())
            {
                return context.tppointstatus.ToArray();
            }
        }

        public static tppointstatu GetPpointstatus(string PPointid)
        {
            int PPointStatusIdentifier;

            if (int.TryParse(PPointid, out PPointStatusIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    return context.tppointstatus.FirstOrDefault(post => post.ID_STATUS == PPointStatusIdentifier);
                }
            }

            return null;
        }


        public static tppointstatu CreatePPointStatus(tppointstatu post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.tppointstatus.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static tppointstatu UpdatePPointStatus(tppointstatu post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }

            return post;
        }

        public static void DeletePPointStatus(string PPointid)
        {
            int PPointStatusIdentifier;

            if (int.TryParse(PPointid, out PPointStatusIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    var entity = context.tppointstatus.FirstOrDefault(post => post.ID_STATUS == PPointStatusIdentifier);
                    if (entity != null)
                    {
                        context.tppointstatus.Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
        }

    }

}
