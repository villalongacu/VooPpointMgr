using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using VooPPointMgr.Data;

namespace VooPPointMgr.Data
{
    public class PpointRepository
    {
        public static tppoint[] GetPPoints()
        {
            using (vooEntities context = new vooEntities())
            {
                return context.tppoints.ToArray();
            }
        }

        public static List<tppoint> SearchPPointByName(string ppointName)
        {
            using (vooEntities context = new vooEntities())
            {
                var query = from ppoint in context.tppoints
                            where ppoint.IIS_NAME.Contains(ppointName)
                            select ppoint;
            
              return query.ToList();
            }
        }
 

        public static tppoint GetPPoint(string PPointid)
        {
            int PPointIdentifier;

            if (int.TryParse(PPointid, out PPointIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    return context.tppoints.FirstOrDefault(post => post.ID_PPOINT == PPointIdentifier);
                }
            }

            return null;
        }


        public static tppoint CreatePPoint(tppoint post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.tppoints.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static tppoint UpdatePPoint(tppoint post)
        {
            using (vooEntities context = new vooEntities())
            {
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }

            return post;
        }

        public static void DeletePPoint(string PPointid)
        {
            int PPointIdentifier;

            if (int.TryParse(PPointid, out PPointIdentifier))
            {
                using (vooEntities context = new vooEntities())
                {
                    var entity = context.tppoints.FirstOrDefault(post => post.ID_PPOINT == PPointIdentifier);
                    if (entity != null)
                    {
                        context.tppoints.Remove(entity);
                        context.SaveChanges();
                    }
                }
            }
        }

    }
}
