using Microsoft.EntityFrameworkCore;
using sm_center_TT.Models;

namespace sm_center_TT.Services
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        {
        }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Polyclinic> Polyclinics { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cabinet>().HasData(
                  new Cabinet() { Id =10, Number = 100, },
                  new Cabinet() { Id = 1, Number = 101},
                  new Cabinet() { Id=2, Number = 102 },
                  new Cabinet() {Id = 3, Number = 103 },
                  new Cabinet() {Id = 4, Number = 104 },
                  new Cabinet() {Id =5, Number = 105 },
                  new Cabinet() { Id =6, Number = 108, },
                  new Cabinet() { Id =7, Number = 109},
                  new Cabinet() { Id =8, Number = 110},
                  new Cabinet() { Id =9, Number = 107});

            modelBuilder.Entity<Specialization>().HasData(
                 new Specialization() { Id =1, Name = "Врач-кардиолог" },
                 new Specialization() { Id =2, Name = "Врач-отоларинголог" },
                 new Specialization() { Id =3, Name = "Врач-терапевт" },
                 new Specialization() { Id =4, Name = "Врач-уролог" },
                 new Specialization() { Id =5, Name = "Врач-акушер-гинеколог" },
                 new Specialization() { Id =6, Name = "Врач-ревматолог" },
                 new Specialization() { Id =7, Name = "Врач-офтальмолог" },
                 new Specialization() { Id =8, Name = "Врач-дерматовенеролог" },
                 new Specialization() { Id =9, Name = "Врач-психиатр" },
                 new Specialization() { Id =10, Name = "Врач мануальной терапии" }
                 );
            modelBuilder.Entity<Polyclinic>().HasData(
                    new Polyclinic() { Id =1, Number = 1 },
                    new Polyclinic() { Id =2, Number = 2 },
                    new Polyclinic() {Id = 3, Number = 3 },
                    new Polyclinic() {Id = 4, Number = 4 },
                    new Polyclinic() {Id = 5, Number = 5 },
                    new Polyclinic() {Id = 6, Number = 6 },
                    new Polyclinic() {Id = 7, Number = 7 },
                    new Polyclinic() {Id = 8, Number = 8 },
                    new Polyclinic() {Id = 9, Number = 9 },
                    new Polyclinic() {Id = 10,   Number = 10 }
                    );
            modelBuilder.Entity<Doctor>().HasData(
                   new Doctor() { Id = 1, FullName = "Соколов Роман Кириллович", CabinetId = 5, PolyclinicId = null, SpecializationId = 3 },
                   new Doctor() { Id = 2, FullName = "Ермолаева Алиса Кирилловна", CabinetId = 6, PolyclinicId = 1, SpecializationId = 2 },
                   new Doctor() { Id = 3, FullName = "Лосева Марьям Артемьевна", CabinetId = 7, PolyclinicId = 2, SpecializationId = 1 },
                   new Doctor() { Id =4, FullName = "Константинова Виктория Ильинична", CabinetId = 8, PolyclinicId = 3, SpecializationId = 10 },
                   new Doctor() { Id =5, FullName = "Антипов Даниил Савельевич", CabinetId = 9, PolyclinicId = 4, SpecializationId = 9 },
                   new Doctor() { Id =6, FullName = "Ермаков Владислав Ильич", CabinetId = 10, PolyclinicId = 5, SpecializationId = 8 },
                   new Doctor() { Id =7, FullName = "Колесникова Полина Егоровна", CabinetId = 1, PolyclinicId = 6, SpecializationId = 7 },
                   new Doctor() { Id =8, FullName = "Владимирова Аделина Львовна", CabinetId = 2, PolyclinicId = 7, SpecializationId = 6 },
                   new Doctor() { Id =9, FullName = "Гордеев Артемий Семёнович", CabinetId = 3, PolyclinicId = 8, SpecializationId = 5 },
                   new Doctor() { Id =10, FullName = "Кириллова Виктория Владимировна", CabinetId = 4, PolyclinicId = 9, SpecializationId = 4 },
                   new Doctor() { Id =11, FullName = "Гришина София Матвеевна", CabinetId = 5, PolyclinicId = 10, SpecializationId = 3 },
                   new Doctor() { Id = 12, FullName = "Ушаков Василий Александрович", CabinetId = 6, PolyclinicId = null, SpecializationId = 2 },
                   new Doctor() { Id = 13, FullName = "Соловьев Иван Маркович", CabinetId = 7, PolyclinicId = 1, SpecializationId = 1 },
                   new Doctor() { Id = 14, FullName = "Пахомова Вероника Данииловна", CabinetId = 8, PolyclinicId = 2, SpecializationId = 10 },
                   new Doctor() { Id = 15, FullName = "Зайцев Михаил Михайлович", CabinetId = 9, PolyclinicId = 3, SpecializationId = 9 },
                   new Doctor() { Id = 16, FullName = "Сафонова Варвара Дмитриевна", CabinetId = 10, PolyclinicId = 4, SpecializationId = 8 },
                   new Doctor() { Id = 17, FullName = "Титова Ариана Фёдоровна", CabinetId = 1, PolyclinicId = 5, SpecializationId = 7 },
                   new Doctor() { Id = 18, FullName = "Маркова Ева Владимировна", CabinetId = 2, PolyclinicId = 6, SpecializationId = 6 },
                   new Doctor() { Id = 19, FullName = "Абрамова Дарья Петровна", CabinetId = 3, PolyclinicId = 7, SpecializationId = 5 },
                   new Doctor() { Id = 20, FullName = "Степанова Алиса Григорьевна", CabinetId = 4, PolyclinicId = null, SpecializationId = 4 }
                   );

            modelBuilder.Entity<Patient>().HasData(
                  new Patient() { Id = 1, FirstName = "Павлов ", SecondName = "Максим ", MiddleName = "Ильич", BirthDay = new DateTime(2000, 5, 16), IsMale = true, Adderss = "Россия, г. Калининград, Космонавтов ул., д. 25 кв.18", PolyclinicId = 1 },
                  new Patient() { Id = 2, FirstName = "Воронина ", SecondName = "Ева ", MiddleName = "Даниловна", BirthDay = new DateTime(2000, 5, 16), IsMale = false, Adderss = "Россия, г. Петрозаводск, Ленинская ул., д. 21 кв.19", PolyclinicId = 2 },
                  new Patient() { Id = 3, FirstName = "Измайлова ", SecondName = "Варвара ", MiddleName = "Олеговна", BirthDay = new DateTime(2000, 5, 16), IsMale = false, Adderss = "Россия, г. Подольск, Октябрьская ул., д. 21 кв.158", PolyclinicId = 3 },
                  new Patient() { Id = 4, FirstName = "Поляков ", SecondName = "Демьян ", MiddleName = "Даниилович", BirthDay = new DateTime(2000, 5, 16), IsMale = true, Adderss = "Россия, г. Черкесск, Лесной пер., д. 23 кв.58", PolyclinicId = 4 },
                  new Patient() { Id = 5, FirstName = "Соколова ", SecondName = "Анна ", MiddleName = "Владимировна", BirthDay = new DateTime(2000, 5, 16), IsMale = false, Adderss = "Россия, г. Ангарск, Ленина В.И.ул., д. 9 кв.84", PolyclinicId = 6 },
                  new Patient() { Id = 6, FirstName = "Горюнов ", SecondName = "Тимур ", MiddleName = "Иванович", BirthDay = new DateTime(2000, 5, 16), IsMale = true, Adderss = "Россия, г. Евпатория, Колхозный пер., д. 20 кв.59", PolyclinicId = 7 },
                  new Patient() { Id = 7, FirstName = "Лебедев ", SecondName = "Константин ", MiddleName = "Тимофеевич", BirthDay = new DateTime(2000, 5, 16), IsMale = true, Adderss = "Россия, г. Кострома, ЯнкиКупалы ул., д. 2 кв.213", PolyclinicId = 8 },
                  new Patient() { Id = 8, FirstName = "Воронин ", SecondName = "Кирилл ", MiddleName = "Макарович", BirthDay = new DateTime(2000, 5, 16), IsMale = true, Adderss = "Россия, г. Рубцовск, Мирная ул., д. 13 кв.24", PolyclinicId = 9 });


        }
    }
}
