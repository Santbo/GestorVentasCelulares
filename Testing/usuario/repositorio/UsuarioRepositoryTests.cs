using GestionVentasCel.data;
using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.models.usuario;
using GestionVentasCel.repository.usuario.impl;
using Microsoft.EntityFrameworkCore;

namespace Testing.usuario;

public class UsuarioRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly UsuarioRepositoryImpl _repository;

    public UsuarioRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _repository = new UsuarioRepositoryImpl(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    [Fact]
    public void Add_DebeAgregarUsuarioCorrectamente()
    {
        // Arrange
        var usuario = new Usuario
        {
            Username = "testuser",
            Password = "password123",
            Rol = RolEnum.Vendedor,
            Nombre = "Juan",
            Apellido = "Pérez",
            Telefono = "123456789",
            Dni = "12345678",
            Email = "juan@test.com",
            Activo = true
        };

        // Act
        _repository.Add(usuario);

        // Assert
        var usuarioGuardado = _context.Usuarios.Find(usuario.Id);
        Assert.NotNull(usuarioGuardado);
        Assert.Equal("testuser", usuarioGuardado.Username);
        Assert.Equal("Juan", usuarioGuardado.Nombre);
    }

    [Fact]
    public void GetById_DebeRetornarUsuarioCuandoExiste()
    {
        // Arrange
        var usuario = new Usuario
        {
            Username = "testuser2",
            Password = "password123",
            Rol = RolEnum.Admin,
            Nombre = "María",
            Apellido = "González",
            Activo = true
        };
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        // Act
        var resultado = _repository.GetById(usuario.Id);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("testuser2", resultado.Username);
        Assert.Equal("María", resultado.Nombre);
    }

    [Fact]
    public void GetById_DebeRetornarNullCuandoNoExiste()
    {
        // Arrange
        int idInexistente = 999;

        // Act
        var resultado = _repository.GetById(idInexistente);

        // Assert
        Assert.Null(resultado);
    }

    [Fact]
    public void GetByUsername_DebeRetornarUsuarioCuandoExiste()
    {
        // Arrange
        var usuario = new Usuario
        {
            Username = "usuariotest",
            Password = "password123",
            Rol = RolEnum.Tecnico,
            Nombre = "Carlos",
            Apellido = "Rodríguez",
            Activo = true
        };
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        // Act
        var resultado = _repository.GetByUsername("usuariotest");

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("Carlos", resultado.Nombre);
        Assert.Equal(RolEnum.Tecnico, resultado.Rol);
    }

    [Fact]
    public void GetByUsername_DebeRetornarNullCuandoNoExiste()
    {
        // Arrange
        string usernameInexistente = "usuarioInexistente";

        // Act
        var resultado = _repository.GetByUsername(usernameInexistente);

        // Assert
        Assert.Null(resultado);
    }

    [Fact]
    public void GetAll_DebeRetornarTodosLosUsuarios()
    {
        // Arrange
        var usuario1 = new Usuario
        {
            Username = "user1",
            Password = "pass1",
            Rol = RolEnum.Admin,
            Nombre = "Usuario",
            Apellido = "Uno",
            Activo = true
        };
        var usuario2 = new Usuario
        {
            Username = "user2",
            Password = "pass2",
            Rol = RolEnum.Vendedor,
            Nombre = "Usuario",
            Apellido = "Dos",
            Activo = true
        };
        _context.Usuarios.AddRange(usuario1, usuario2);
        _context.SaveChanges();

        // Act
        var resultado = _repository.GetAll();

        // Assert
        Assert.Equal(2, resultado.Count());
        Assert.Contains(resultado, u => u.Username == "user1");
        Assert.Contains(resultado, u => u.Username == "user2");
    }

    [Fact]
    public void Update_DebeActualizarUsuarioCorrectamente()
    {
        // Arrange
        var usuario = new Usuario
        {
            Username = "userupdate",
            Password = "oldpass",
            Rol = RolEnum.Vendedor,
            Nombre = "Original",
            Apellido = "Apellido",
            Activo = true
        };
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        // Act
        usuario.Nombre = "Actualizado";
        usuario.Password = "newpass";
        _repository.Update(usuario);

        // Assert
        var usuarioActualizado = _context.Usuarios.Find(usuario.Id);
        Assert.NotNull(usuarioActualizado);
        Assert.Equal("Actualizado", usuarioActualizado.Nombre);
        Assert.Equal("newpass", usuarioActualizado.Password);
    }

    [Fact]
    public void Exist_DebeRetornarTrueCuandoUsuarioExiste()
    {
        // Arrange
        var usuario = new Usuario
        {
            Username = "existente",
            Password = "pass",
            Rol = RolEnum.Admin,
            Nombre = "Existe",
            Activo = true
        };
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        // Act
        var resultado = _repository.Exist(usuario.Id);

        // Assert
        Assert.True(resultado);
    }

    [Fact]
    public void Exist_DebeRetornarFalseCuandoUsuarioNoExiste()
    {
        // Arrange
        int idInexistente = 999;

        // Act
        var resultado = _repository.Exist(idInexistente);

        // Assert
        Assert.False(resultado);
    }
}
