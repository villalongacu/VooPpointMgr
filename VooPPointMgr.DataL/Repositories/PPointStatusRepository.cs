using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace VooPPointMgr.DataL
{
    public class PPointStatusRepository
    {
        public static tppointstatu[] GetAllPpointStatus()
        {
            using (vEntities context = new vEntities())
            {
                return context.tppointstatus.ToArray();
            }
        }

        public static tppointstatu GetPpointstatus(string PPointid)
        {
            int PPointStatusIdentifier;

            if (int.TryParse(PPointid, out PPointStatusIdentifier))
            {
                using (vEntities context = new vEntities())
                {
                    return context.tppointstatus.FirstOrDefault(post => post.ID_STATUS == PPointStatusIdentifier);
                }
            }

            return null;
        }


        public static tppointstatu CreatePPointStatus(tppointstatu post)
        {
            using (vEntities context = new vEntities())
            {
                context.tppointstatus.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static tppointstatu UpdatePPointStatus(tppointstatu post)
        {
            using (vEntities context = new vEntities())
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
                using (vEntities context = new vEntities())
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
