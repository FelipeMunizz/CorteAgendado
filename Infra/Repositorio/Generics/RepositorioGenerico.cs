using Domain.Interfaces.Generics;
using Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repositorio.Generics;

public class RepositorioGenerico<T> : InterfaceGeneric<T>, IDisposable where T : class
{
    private readonly DbContextOptions<AppDbContext> _optionsBuilder;

    public RepositorioGenerico()
    {
        _optionsBuilder = new DbContextOptions<AppDbContext>();
    }

    public async Task Add(T Objeto)
    {
        using (var data = new AppDbContext(_optionsBuilder))
        {
            await data.Set<T>().AddAsync(Objeto);
            await data.SaveChangesAsync();
        }
    }

    public async Task Update(T Objeto)
    {
        using (var data = new AppDbContext(_optionsBuilder))
        {
            data.Set<T>().Update(Objeto);
            await data.SaveChangesAsync();
        }
    }

    public async Task Delete(T Objeto)
    {
        using (var data = new AppDbContext(_optionsBuilder))
        {
            data.Set<T>().Remove(Objeto);
            await data.SaveChangesAsync();
        }
    }
    public async Task<List<T>> List()
    {
        using (var data = new AppDbContext(_optionsBuilder))
        {
            return await data.Set<T>().ToListAsync();
        }
    }

    public async Task<T> GetEntityById(int Id)
    {
        using (var data = new AppDbContext(_optionsBuilder))
        {
            return await data.Set<T>().FindAsync(Id);
        }
    }

    #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
    // Flag: Has Dispose already been called?
    bool disposed = false;
    // Instantiate a SafeHandle instance.
    SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            handle.Dispose();
            // Free any other managed objects here.
            //
        }

        disposed = true;
    }
    #endregion
}
