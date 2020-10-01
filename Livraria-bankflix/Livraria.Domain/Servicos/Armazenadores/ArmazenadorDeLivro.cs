﻿using Livraria.Common.Interfaces.Notifications;
using Livraria.Common.Notifications;
using Livraria.Common.Utils;
using Livraria.Domain.Dto;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Alteradores;
using Livraria.Domain.Interfaces.Armazenadores;
using Livraria.Domain.Interfaces.Repository;
using Livraria.Domain.Interfaces.Validadores;
using System.Threading.Tasks;

namespace Livraria.Domain.Servicos.Armazenadores
{
    public class ArmazenadorDeLivro : IArmazenadorDeLivro
    {
        // private readonly Notify _notify;
        private readonly IDomainNotificationHandler<DomainNotification> _notificacaoDeDominio;
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IValidadorDelivro _validadorDelivro;
        private readonly IAlteradorDeLivro _alteradorDeLivro;

        public ArmazenadorDeLivro(
            //INotify notify,
            IDomainNotificationHandler<DomainNotification> notificacaoDeDominio,
            ILivroRepositorio livroRepositorio,
            IValidadorDelivro validadorDelivro,
            IAlteradorDeLivro alteradorDeLivro)
        {
            // _notify = notify.Invoke();
            _notificacaoDeDominio = notificacaoDeDominio;
            _livroRepositorio = livroRepositorio;
            _validadorDelivro = validadorDelivro;
            _alteradorDeLivro = alteradorDeLivro;
        }
        public async Task Armazenar(LivroDto dto)
        {
            _validadorDelivro.Validar(dto);
            var livro = Novolivro(dto);

            if (!_notificacaoDeDominio.HasNotifications())
            {
                if (dto.Id.Value > Constantes.Zero)
                {
                    livro = await _livroRepositorio.ObterPorIdAsync(dto.Id.Value);
                    _alteradorDeLivro.Alterar(livro, dto);
                }

                if (livro.Validar() && livro.Id == Constantes.Zero)
                {
                    var livroExistente = await _livroRepositorio.ObterPorTitulo(livro.Titulo);
                    _validadorDelivro.ValidarSeLivroExiste(livroExistente);

                    if (!_notificacaoDeDominio.HasNotifications())
                        await _livroRepositorio.AdicionarAsync(livro);
                }
                else
                {
                    //_notify.NewNotification(livro.ValidationResult);
                    await _notificacaoDeDominio.NotificarValidacao(livro.ValidationResult);
                }

            }

        }

        private Livro Novolivro(LivroDto dto)
        {
            var livro =  new Livro(dto.Titulo, dto.AnoDePublicacao, dto.Edicao, dto.AutorId);
            if (dto.Autor != null)
                livro.AlterarAutor(NovoAutor(dto.Autor));
            return livro;
        }

        private Autor NovoAutor(AutorDto dto)
        {
            var autor = new Autor(dto.Nome);
            autor.DefinirId(dto.Id.Value);
            return autor;
        }
    }
}
