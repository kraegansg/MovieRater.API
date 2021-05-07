using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class RatingService
    {
        public bool CreateRatings(RatingCreate model)
        {
            var entity =
                new Ratings()
                {
                    IsRecommended = model.IsRecommended,
                    IsFamilyFriendly = model.IsFamilyFriendly,
                    ActualRating = model.ActualRating
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ratings
                    .Select(
                        e =>
                        new RatingListItem
                        {
                            FilmId = e.FilmId,
                            TVId = e.TVId,
                            Title = e.Title
                        });
                return query.ToArray();
            }
        }

        public RatingDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.TVId && e.FilmId == id);//?
                return
                    new RatingDetail
                    {
                        TVId = entity.TVId,
                        FilmId = entity.FilmId,
                        Title = entity.Title
                    };
            }
        }

        public bool UpdateRating (RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.TVId && e.FilmId == id);//?

                entity.Title = model.Title;
                entity.CurrentRating = model.CurrentRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int TVId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.TVId == tvId && e.FilmId == filmId);//?

                ctx.TVs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
