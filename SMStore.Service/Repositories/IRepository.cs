using System;
using System.Collections.Generic;
using System.Linq.Expressions;  // Expressionlar veriyi sorgularken lambda evpressision kullanabilmemii sağlar. p=>.ıd ==id gibi
using System.Text;
using System.Threading.Tasks;

namespace SMStore.Service.Repositories
{
    public interface IRepository<T> where T : class //IRepository interface i <T> yapısı ile generic hale getirildi. buradaki T dışarıdan gönderilecek veri(class,değiken vb ) where T : class ise buraya gönderilecek parametre class olmak zzorundadır demek
    {
        // Burada Uygulamada kullanacağımız crud metotlarının imzalarını belirliyoruz.

        List<T> GetAll(); // verilerin hepsini getirecek metod
        List<T> GetAll(Expression<Func<T,bool>> expression);  // uygulamada bu metodu lamda expression ile kulanabilmek için

        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int SaveChanges();
        // Asenkron Metotlar

        Task<T> FindAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity); //Asenkron void metot
        Task<int> SaveChangesAsync();


    }
}
