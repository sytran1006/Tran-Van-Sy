using Microsoft.EntityFrameworkCore;


namespace JamesTranproject.Models
{
    public class ReactContext : DbContext

    {
        public ReactContext(DbContextOptions<ReactContext> options)
            : base(options)
        {
        }

        public DbSet<Anouncement> Anouncements { get; set; }
        public DbSet<News> News { get; set; } = null!;
        public DbSet<ImageGallery> ImageGallerys { get; set; }
        public DbSet<VideoGallery> VideoGallerys { get; set; }
        public DbSet<QuickLink> QuickLinks { get; set; }
        public DbSet<Events> Events { get; set; } 
        public DbSet<HowDoI> HowDoIs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           // Code to seed data

             //anouncement
            modelBuilder.Entity<Anouncement>().HasData(new Anouncement
            {
                Id = 1,
                Title = "New Learing System Is Live",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.image_gallery",
                DateTimeUse = "05/Jan/2021",
                ResourceUse = "Human Resource"
            });
            modelBuilder.Entity<Anouncement>().HasData(new Anouncement
            {
                Id = 2,
                Title = "New Learing System Is Live",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.image_gallery_1",
                DateTimeUse = "05/Jan/2021",
                ResourceUse = "Human Resource"
            });
            modelBuilder.Entity<Anouncement>().HasData(new Anouncement
            {
                Id = 3,
                Title = "New Learing System Is Live",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.image_gallery_2",
                DateTimeUse = "05/Jan/2021",
                ResourceUse = "Human Resource"
            });
            modelBuilder.Entity<Anouncement>().HasData(new Anouncement
            {
                Id = 4,
                Title = "New Learing System Is Live",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.image_gallery_3",
                DateTimeUse = "05/Jan/2021",
                ResourceUse = "Human Resource"
            });

            //new
            modelBuilder.Entity<News>().HasData(new News
            {
                Id = 1,
                Title = "Tomorrow Healthy Check",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.markgroup2",
                DateTimeUse = "05/Jan/2021"
            });
            modelBuilder.Entity<News>().HasData(new News
            {
                Id = 2,
                Title = "Tomorrow Healthy Check",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.markgroup_1",
                DateTimeUse = "05/Jan/2021"
            });
            modelBuilder.Entity<News>().HasData(new News
            {
                Id = 3,
                Title = "Tomorrow Healthy Check",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.markgroup_2",
                DateTimeUse = "05/Jan/2021"
            });
            modelBuilder.Entity<News>().HasData(new News
            {
                Id = 4,
                Title = "Tomorrow Healthy Check",
                Introduction = "New Wellness Lorem ipsum dolor sit amet, consetetur sadipscing elitrinvidunt ut labore et dolore aaliquya erat, sed diam voluptuaaa vero eos et accusam et justo duo d ea rebum.",
                Img = "Image.markgroup_3",
                DateTimeUse = "05/Jan/2021"
            });

            //image gallery
            modelBuilder.Entity<ImageGallery>().HasData(new ImageGallery
            {
                Id = 1,
                Img = "Image.image_gallery_1",
            });
            modelBuilder.Entity<ImageGallery>().HasData(new ImageGallery
            {
                Id = 2,
                Img = "Image.image_gallery_2",
            });
            modelBuilder.Entity<ImageGallery>().HasData(new ImageGallery
            {
                Id = 3,
                Img = "Image.image_gallery_3",
            });
            modelBuilder.Entity<ImageGallery>().HasData(new ImageGallery
            {
                Id = 4,
                Img = "Image.image_gallery_4",
            });

            //video gallery
            modelBuilder.Entity<VideoGallery>().HasData(new VideoGallery
            {
                Id = 1,
                Video = "Image.video",
            });
            modelBuilder.Entity<VideoGallery>().HasData(new VideoGallery
            {
                Id = 2,
                Video = "Image.video_1",
            });
            modelBuilder.Entity<VideoGallery>().HasData(new VideoGallery
            {
                Id = 3,
                Video = "Image.video_2",
            });

            //quick link
            modelBuilder.Entity<QuickLink>().HasData(new QuickLink
            {
                Id = 1,
                Img = "Image.icon",
                Title = "Training"
            });
            modelBuilder.Entity<QuickLink>().HasData(new QuickLink
            {
                Id = 2,
                Img = "Image.icon_1",
                Title = "Organization"
            });
            modelBuilder.Entity<QuickLink>().HasData(new QuickLink
            {
                Id = 3,
                Img = "Image.icon_2",
                Title = "Task"
            });

            //events
            modelBuilder.Entity<Events>().HasData(new Events
            {
                Id = 1,
                Number = "01",
                Day = "Jan",
                Title = "Register Portal",
                Img = "Image.clock",
                Time = "09:00 AM - 09:30 AM"
            });
            modelBuilder.Entity<Events>().HasData(new Events
            {
                Id = 2,
                Number = "02",
                Day = "Jan",
                Title = "Register Portal",
                Img = "Image.clock",
                Time = "09:00 AM - 09:30 AM"
            });
            modelBuilder.Entity<Events>().HasData(new Events
            {
                Id = 3,
                Number = "03",
                Day = "Jan",
                Title = "Register Portal",
                Img = "Image.clock",
                Time = "09:00 AM - 09:30 AM"
            });
            modelBuilder.Entity<Events>().HasData(new Events
            {
                Id = 4,
                Number = "04",
                Day = "Jan",
                Title = "Register Portal",
                Img = "Image.clock",
                Time = "09:00 AM - 09:30 AM"
            });

            // how do i
            modelBuilder.Entity<HowDoI>().HasData(new HowDoI
            {
                Id = 1,
                IconQuestion = "Image.collapse",
                IconAnswer = "Image.expand",
                Question = "What do you do?",
                Answer = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisiut aliquip ex ea commodo consequat. Duis uis.",
            });
            modelBuilder.Entity<HowDoI>().HasData(new HowDoI
            {
                Id = 2,
                IconQuestion = "Image.collapse",
                IconAnswer = "Image.expand",
                Question = "What do you do?",
                Answer = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisiut aliquip ex ea commodo consequat. Duis uis.",
            });
            modelBuilder.Entity<HowDoI>().HasData(new HowDoI
            {
                Id = 3,
                IconQuestion = "Image.collapse",
                IconAnswer = "Image.expand",
                Question = "What do you do?",
                Answer = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisiut aliquip ex ea commodo consequat. Duis uis.",
            });
        }
    }
}
