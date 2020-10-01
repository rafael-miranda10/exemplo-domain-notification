﻿namespace Livraria.Tests.Livros
{
    public class ArmazenadorDeLivrosTeste
    {
        //private NotifiyHandler _notifiyHandler;
        //private Notify _notify;
        //private readonly Faker _faker;
        //private readonly Mock<ILivroRepositorio> _livroRepositorioMock;
        //private readonly Mock<IValidadorDelivro> _validadorDeLivroMock;
        //private readonly Mock<IAlteradorDeLivro> _alteradorDeLivroMock;
        //private ArmazenadorDeLivro _armazenadorDeLivros;

        //public ArmazenadorDeLivrosTeste()
        //{
        //    _notifiyHandler = new NotifiyHandler();
        //    _notify = new Notify(_notifiyHandler);
        //    _faker = FakerBuilder.Novo().Build();
        //    _livroRepositorioMock = new Mock<ILivroRepositorio>();
        //    _validadorDeLivroMock = new Mock<IValidadorDelivro>();
        //    _alteradorDeLivroMock = new Mock<IAlteradorDeLivro>();
        //    _armazenadorDeLivros = new ArmazenadorDeLivro(
        //        _notify,
        //        _livroRepositorioMock.Object,
        //        _validadorDeLivroMock.Object,
        //        _alteradorDeLivroMock.Object);
        //}

        //[Fact]
        //public async Task DeveArmazenarLivro()
        //{
        //    //arrange
        //    var dto = ObterDtoComAutorValido();
        //    Livro livro = null;
        //    _livroRepositorioMock.Setup(x => x.ObterPorTitulo(It.IsAny<string>())).ReturnsAsync(livro);

        //    //act
        //    await _armazenadorDeLivros.Armazenar(dto);

        //    //assert
        //    _livroRepositorioMock.Verify(x => x.AdicionarAsync(It.IsAny<Livro>()), Times.Once);
        //}

        //[Fact]
        //public async Task NaoDeveArmazenarLivro()
        //{
        //    //arrange
        //    var dto = ObterDtoComAutorValido();
        //    Livro livro = LivroBuilder.Novo().ComTitulo(dto.Titulo).Build();
        //    CriaSetUpValidadorDeLivroValidarSeLivroExiste(livro);
        //    CriaSetUpRepositorioLivroObterPorTitulo(livro);
        //    _armazenadorDeLivros = new ArmazenadorDeLivro(
        //        _notify,
        //        _livroRepositorioMock.Object,
        //        _validadorDeLivroMock.Object,
        //        _alteradorDeLivroMock.Object);

        //    //act
        //    await _armazenadorDeLivros.Armazenar(dto);

        //    //assert
        //    var achou = _notify.Invoke().GetNotifications().Any(x => x.Value == Resources.LivroJaExiste);
        //    Assert.True(achou);
        //    _livroRepositorioMock.Verify(x => x.AdicionarAsync(It.IsAny<Livro>()), Times.Never);
        //}

        //private void CriaSetUpRepositorioLivroObterPorTitulo(Livro livro)
        //{
        //    _livroRepositorioMock.Setup(x => x.ObterPorTitulo(It.IsAny<string>())).ReturnsAsync(livro);
        //}

        //private void CriaSetUpValidadorDeLivroValidarSeLivroExiste(Livro livro)
        //{
        //    _validadorDeLivroMock.Setup(x => x.ValidarSeLivroExiste(livro))
        //   .Callback(() =>
        //   {
        //       _notify.Invoke().NewNotification(Resources.LivroEntidade, Resources.LivroJaExiste);
        //   });
        //}

        //private LivroDto ObterDtoComAutorValido()
        //{
        //    return new LivroDto()
        //    {
        //        AnoDePublicacao = _faker.Random.Int(Constantes.MilNovecentosENoventa, Constantes.DoisMilEVinte),
        //        AutorId = Constantes.Um,
        //        Edicao = _faker.Random.Int(Constantes.Um, Constantes.Dez),
        //        Id = Constantes.Zero,
        //        Titulo = _faker.Lorem.Words(Constantes.Cinco).ToString()
        //    };
        //}
    }
}
