using GestionVentasCel.enumerations.usuarios;
using GestionVentasCel.exceptions.usuario;
using GestionVentasCel.models.usuario;
using GestionVentasCel.repository.usuario;
using GestionVentasCel.service.usuario.impl;
using Moq;
using Xunit;

namespace GestionVentasCel.Tests.usuario.service
{
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
            // Arrange
            _mockRepository.Setup(r => r.GetByUsername(It.IsAny<string>())).Returns((Usuario?)null);

            // Act
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

            // Assert
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
            // Arrange
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

            // Act & Assert
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
            // Arrange
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

            // Act
            var resultado = _service.Login("testuser", "password123");

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("testuser", resultado.Username);
            Assert.Equal(RolEnum.Admin, resultado.Rol);
        }

        [Fact]
        public void Login_DebeRetornarNullCuandoUsuarioNoExiste()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetByUsername(It.IsAny<string>())).Returns((Usuario?)null);

            // Act
            var resultado = _service.Login("inexistente", "password");

            // Assert
            Assert.Null(resultado);
        }

        [Fact]
        public void Login_DebeRetornarNullCuandoPasswordEsIncorrecto()
        {
            // Arrange
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

            // Act
            var resultado = _service.Login("testuser", "wrongpassword");

            // Assert
            Assert.Null(resultado);
        }

        [Fact]
        public void Login_DebeRetornarNullCuandoUsuarioNoEstaActivo()
        {
            // Arrange
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

            // Act
            var resultado = _service.Login("inactivo", "password123");

            // Assert
            Assert.Null(resultado);
        }

        [Fact]
        public void ListarUsuarios_DebeRetornarTodosLosUsuarios()
        {
            // Arrange
            var usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Username = "user1", Password = "pass1", Rol = RolEnum.Admin, Nombre = "Uno", Activo = true },
                new Usuario { Id = 2, Username = "user2", Password = "pass2", Rol = RolEnum.Vendedor, Nombre = "Dos", Activo = true }
            };
            _mockRepository.Setup(r => r.GetAll()).Returns(usuarios);

            // Act
            var resultado = _service.ListarUsuarios();

            // Assert
            Assert.Equal(2, resultado.Count());
            Assert.Contains(resultado, u => u.Username == "user1");
            Assert.Contains(resultado, u => u.Username == "user2");
        }

        [Fact]
        public void UpdateUsuario_DebeActualizarUsuarioCuandoExiste()
        {
            // Arrange
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

            // Act
            _service.UpdateUsuario(usuario);

            // Assert
            _mockRepository.Verify(r => r.Update(It.Is<Usuario>(u => u.Id == 1)), Times.Once);
        }

        [Fact]
        public void UpdateUsuario_DebeLanzarExcepcionCuandoUsuarioNoExiste()
        {
            // Arrange
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

            // Act & Assert
            var exception = Assert.Throws<UsuarioNoEncontradoException>(() =>
                _service.UpdateUsuario(usuario)
            );

            Assert.Equal("Usuario no encontrado", exception.Message);
            _mockRepository.Verify(r => r.Update(It.IsAny<Usuario>()), Times.Never);
        }

        [Fact]
        public void ToggleActivo_DebeAlternarEstadoActivoCuandoUsuarioExiste()
        {
            // Arrange
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

            // Act
            _service.ToggleActivo(1);

            // Assert
            Assert.False(usuario.Activo); // Debe cambiar de true a false
            _mockRepository.Verify(r => r.Update(It.Is<Usuario>(u => u.Id == 1 && !u.Activo)), Times.Once);
        }

        [Fact]
        public void ToggleActivo_DebeLanzarExcepcionCuandoUsuarioNoExiste()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetById(999)).Returns((Usuario?)null);

            // Act & Assert
            var exception = Assert.Throws<UsuarioNoEncontradoException>(() =>
                _service.ToggleActivo(999)
            );

            Assert.Equal("Usuario no encontrado", exception.Message);
            _mockRepository.Verify(r => r.Update(It.IsAny<Usuario>()), Times.Never);
        }

        [Fact]
        public void GetById_DebeRetornarUsuarioCuandoExiste()
        {
            // Arrange
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

            // Act
            var resultado = _service.GetById(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(1, resultado.Id);
            Assert.Equal("testuser", resultado.Username);
        }

        [Fact]
        public void GetById_DebeRetornarNullCuandoUsuarioNoExiste()
        {
            // Arrange
            _mockRepository.Setup(r => r.GetById(999)).Returns((Usuario?)null);

            // Act
            var resultado = _service.GetById(999);

            // Assert
            Assert.Null(resultado);
        }
    }
}
