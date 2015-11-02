using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace VooPPointMgr.DataL
{
    public class PpointRepository
    {
        public static tppoint[] GetPPoints()
        {
            using (vEntities context = new vEntities())
            {
                return context.tppoints.ToArray();
            }
        }

        public static List<tppoint> SearchPPointByName(string ppointName)
        {
            using (vEntities context = new vEntities())
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
                using (vEntities context = new vEntities())
                {
                    return context.tppoints.FirstOrDefault(post => post.ID_PPOINT == PPointIdentifier);
                }
            }

            return null;
        }

        public static bool GetPPointStatus(string PPointid)
        {
            using (vEntities context = new vEntities())
            {
                return context.tppoints.FirstOrDefault(post => post.ID_PPOINT == int.Parse(PPointid)).IN_USE;
            }
        }


        public static tppoint GetAvailablePPoint()
        {
             
            using (vEntities context = new vEntities())
                {
                   var tempPP = context.tppoints.FirstOrDefault(post => post.IN_USE == false);
                
                // if there are no more publishin points available it creates a new one in Azure
                    return tempPP == null ? CreateAMSPPoint(new tppoint() {}) : tempPP;
                    
                }
         
        }

        public static tppoint CreatePPoint(tppoint post)
        {
            using (vEntities context = new vEntities())
            {
                context.tppoints.Add(post);
                context.SaveChanges();
            }

            return post;
        }

        public static tppoint CreateAMSPPoint(tppoint post)
        {


            using (vEntities context = new vEntities())
            {
                context.tppoints.Add(post);
                context.SaveChanges();
            }

            return post;
        }


        public static tppoint UpdatePPoint(tppoint post)
        {
            using (vEntities context = new vEntities())
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
                using (vEntities context = new vEntities())
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
