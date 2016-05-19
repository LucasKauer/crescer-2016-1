using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class PedidoServico
    {
        private IPedidoRepositorio _pedidoRepositorio;
        private IServicoEmail _servicoEmail;

        public PedidoServico(IPedidoRepositorio pedidoRepositorio, IServicoEmail servicoEmail)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _servicoEmail = servicoEmail;
        }

        public void FecharPedido(Pedido pedido)
        {
            pedido.FecharPedido();
            _pedidoRepositorio.SalvarPedido(pedido);

            _servicoEmail.Enviar(
                pedido.Cliente,
                "cwi@cwi.com.br",
                "Pedido fechado com sucesso!",
                pedido.ToString());
        }
    }
}
