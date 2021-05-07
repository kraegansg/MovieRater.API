using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
   public class TVService
    {
        public bool CreateTV(TVCreate model)
        {
            var entity =
                new TV()
                {
                    Title = model.Title,
                    Channel = model.Channel,
                    Genre = model.Genre,
                    //TVRating = model.TVRating,
                    //RatingStars = model.RatingStars
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.TVs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TVListItem> GetTVs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .TVs
                    .Select(
                        e =>
                        new TVListItem
                        {
                            TVId = e.TVId,
                            Title = e.Title,
                            RatingStars = e.RatingStars
                        });
                return query.ToArray();
            }
        }

        public TVDetail GetTVById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TVs
                    .Single(e => e.TVId == id);
                return
                    new TVDetail
                    {
                        TVId = entity.TVId,
                        Title = entity.Title,
                        RatingStars = entity.RatingStars
                    };
            }
        }

        public bool UpdateTV(TVEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TVs
                    .Single(e => e.TVId == model.TVId);

                entity.Title = model.Title;
                //entity.RatingStars = model.RatingStars;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTV(int TVId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TVs
                    .Single(e => e.TVId == tvId);

                ctx.TVs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
