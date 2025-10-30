using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.exceptions.usuario;
using GestionVentasCel.models.usuario;
using GestionVentasCel.repository.usuario;
using GestionVentasCel.service.usuario.impl;
using Moq;

namespace Testing.usuario;

public class UsuarioServiceTests
{
    private readonly Mock<IUsuarioRepository> _mockRepository;
    private readonly UsuarioServiceImpl _service;

    public UsuarioServiceTests()
    {
        _mockRepository = new Mock<IUsuarioRepository>();
        _service = new UsuarioServiceImpl(_mockRepository.Object);
    }

    [Fact]
    public void RegistrarUsuario_DebeRegistrarUsuarioCorrectamente()
    {
        
        _mockRepository.Setup(r => r.GetByUsername(It.IsAny<string>())).Returns((Usuario?)null);

        
        _service.RegistrarUsuario(
            username: "nuevouser",
            password: "password123",
            rol: "Admin",
            nombre: "Test",
            apellido: "Usuario",
            telefono: "123456789",
            dni: "12345678",
            email: "test@test.com"
        );

        
        _mockRepository.Verify(r => r.Add(It.Is<Usuario>(u =>
            u.Username == "nuevouser" &&
            u.Password == "password123" &&
            u.Rol == RolEnum.Admin &&
            u.Nombre == "Test"
        )), Times.Once);
    }

    [Fact]
    public void RegistrarUsuario_DebeLanzarExcepcionCuandoUsuarioYaExiste()
    {
        
        var usuarioExistente = new Usuario
        {
            Id = 1,
            Username = "existente",
            Password = "pass",
            Rol = RolEnum.Vendedor,
            Nombre = "Usuario",
            Activo = true
        };
        _mockRepository.Setup(r => r.GetByUsername("existente")).Returns(usuarioExistente);

         & Assert
        var exception = Assert.Throws<UsuarioExistenteException>(() =>
            _service.RegistrarUsuario(
                username: "existente",
                password: "password",
                rol: "Admin",
                nombre: "Test",
                apellido: "Usuario",
                telefono: "123456",
                dni: "12345678",
                email: "test@test.com"
            )
        );

        Assert.Equal("El usuario ya existe.", exception.Message);
        _mockRepository.Verify(r => r.Add(It.IsAny<Usuario>()), Times.Never);
    }

    [Fact]
    public void Login_DebeRetornarUsuarioCuandoCredencialesSonCorrectas()
    {
        
        var usuario = new Usuario
        {
            Id = 1,
            Username = "testuser",
            Password = "password123",
            Rol = RolEnum.Admin,
            Nombre = "Test",
            Activo = true
        };
        _mockRepository.Setup(r => r.GetByUsername("testuser")).Returns(usuario);

        
        var resultado = _service.Login("testuser", "password123");

        
        Assert.NotNull(resultado);
        Assert.Equal("testuser", resultado.Username);
        Assert.Equal(RolEnum.Admin, resultado.Rol);
    }

    [Fact]
    public void Login_DebeRetornarNullCuandoUsuarioNoExiste()
    {
        
        _mockRepository.Setup(r => r.GetByUsername(It.IsAny<string>())).Returns((Usuario?)null);

        
        var resultado = _service.Login("inexistente", "password");

        
        Assert.Null(resultado);
    }

    [Fact]
    public void Login_DebeRetornarNullCuandoPasswordEsIncorrecto()
    {
        
        var usuario = new Usuario
        {
            Id = 1,
            Username = "testuser",
            Password = "correctpassword",
            Rol = RolEnum.Vendedor,
            Nombre = "Test",
            Activo = true
        };
        _mockRepository.Setup(r => r.GetByUsername("testuser")).Returns(usuario);

        
        var resultado = _service.Login("testuser", "wrongpassword");

        
        Assert.Null(resultado);
    }

    [Fact]
    public void Login_DebeRetornarNullCuandoUsuarioNoEstaActivo()
    {
        
        var usuario = new Usuario
        {
            Id = 1,
            Username = "inactivo",
            Password = "password123",
            Rol = RolEnum.Vendedor,
            Nombre = "Test",
            Activo = false
        };
        _mockRepository.Setup(r => r.GetByUsername("inactivo")).Returns(usuario);

        
        var resultado = _service.Login("inactivo", "password123");

        
        Assert.Null(resultado);
    }

    [Fact]
    public void ListarUsuarios_DebeRetornarTodosLosUsuarios()
    {
        
        var usuarios = new List<Usuario>
        {
            new Usuario { Id = 1, Username = "user1", Password = "pass1", Rol = RolEnum.Admin, Nombre = "Uno", Activo = true },
            new Usuario { Id = 2, Username = "user2", Password = "pass2", Rol = RolEnum.Vendedor, Nombre = "Dos", Activo = true }
        };
        _mockRepository.Setup(r => r.GetAll()).Returns(usuarios);

        
        var resultado = _service.ListarUsuarios();

        
        Assert.Equal(2, resultado.Count());
        Assert.Contains(resultado, u => u.Username == "user1");
        Assert.Contains(resultado, u => u.Username == "user2");
    }

    [Fact]
    public void UpdateUsuario_DebeActualizarUsuarioCuandoExiste()
    {
        
        var usuario = new Usuario
        {
            Id = 1,
            Username = "testuser",
            Password = "newpass",
            Rol = RolEnum.Admin,
            Nombre = "Actualizado",
            Activo = true
        };
        _mockRepository.Setup(r => r.Exist(1)).Returns(true);

        
        _service.UpdateUsuario(usuario);

        
        _mockRepository.Verify(r => r.Update(It.Is<Usuario>(u => u.Id == 1)), Times.Once);
    }

    [Fact]
    public void UpdateUsuario_DebeLanzarExcepcionCuandoUsuarioNoExiste()
    {
        
        var usuario = new Usuario
        {
            Id = 999,
            Username = "inexistente",
            Password = "pass",
            Rol = RolEnum.Vendedor,
            Nombre = "Test",
            Activo = true
        };
        _mockRepository.Setup(r => r.Exist(999)).Returns(false);

         & Assert
        var exception = Assert.Throws<UsuarioNoEncontradoException>(() =>
            _service.UpdateUsuario(usuario)
        );

        Assert.Equal("Usuario no encontrado", exception.Message);
        _mockRepository.Verify(r => r.Update(It.IsAny<Usuario>()), Times.Never);
    }

    [Fact]
    public void ToggleActivo_DebeAlternarEstadoActivoCuandoUsuarioExiste()
    {
        
        var usuario = new Usuario
        {
            Id = 1,
            Username = "testuser",
            Password = "pass",
            Rol = RolEnum.Vendedor,
            Nombre = "Test",
            Activo = true
        };
        _mockRepository.Setup(r => r.GetById(1)).Returns(usuario);

        
        _service.ToggleActivo(1);

        
        Assert.False(usuario.Activo); // Debe cambiar de true a false
        _mockRepository.Verify(r => r.Update(It.Is<Usuario>(u => u.Id == 1 && !u.Activo)), Times.Once);
    }

    [Fact]
    public void ToggleActivo_DebeLanzarExcepcionCuandoUsuarioNoExiste()
    {
        
        _mockRepository.Setup(r => r.GetById(999)).Returns((Usuario?)null);

         & Assert
        var exception = Assert.Throws<UsuarioNoEncontradoException>(() =>
            _service.ToggleActivo(999)
        );

        Assert.Equal("Usuario no encontrado", exception.Message);
        _mockRepository.Verify(r => r.Update(It.IsAny<Usuario>()), Times.Never);
    }

    [Fact]
    public void GetById_DebeRetornarUsuarioCuandoExiste()
    {
        
        var usuario = new Usuario
        {
            Id = 1,
            Username = "testuser",
            Password = "pass",
            Rol = RolEnum.Admin,
            Nombre = "Test",
            Activo = true
        };
        _mockRepository.Setup(r => r.GetById(1)).Returns(usuario);

        
        var resultado = _service.GetById(1);

        
        Assert.NotNull(resultado);
        Assert.Equal(1, resultado.Id);
        Assert.Equal("testuser", resultado.Username);
    }

    [Fact]
    public void GetById_DebeRetornarNullCuandoUsuarioNoExiste()
    {
        
        _mockRepository.Setup(r => r.GetById(999)).Returns((Usuario?)null);

        
        var resultado = _service.GetById(999);

        
        Assert.Null(resultado);
    }
}
