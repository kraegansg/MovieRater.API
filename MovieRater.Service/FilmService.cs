using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
   public class FilmService
    {
        public bool CreateFilms (FilmCreate model)
        {
            var entity =
                new Film()
                {
                    FilmId = model.FilmId,
                    Title = model.Title,
                    Genre = model.Genre,
                    FilmRating = model.FilmRating,
                    RatingStars = model.RatingStars,
                    //ReleaseDate = model.ReleaseDate
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Films.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FilmListItem> GetFilms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Films
                    .Select(
                        e =>
                        new FilmListItem
                        {
                            FilmId = e.FilmId,
                            Title = e.Title,
                            RatingStars = e.RatingStars
                        });
                return query.ToArray();
            }
        }

        public FilmDetail GetFilmById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                   .Films
                   .Single(e => e.FilmId == id);
                return
                    new FilmDetail
                    {
                        FilmId = entity.FilmId,
                        Title = entity.Title,
                        RatingStars = entity.RatingStars
                    };
            }
        }

        public bool UpdateFilm (FilmEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Films
                    .Single(e => e.FilmId == id);

                entity.Title = model.Title;
                entity.RatingStars = model.RatingStars;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFilm(int FilmId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                   .Films
                   .Single(e => e.FilmId == filmId);//?

                ctx.TVs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
