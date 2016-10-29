using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class NegEntregas
    {
        public List<Tbl_Entregas> ConsultarEntrega(int? intMotoboyId)
        {
            try
            {
                List<Tbl_Entregas> entregaColecao = new List<Tbl_Entregas>();

                using (var bancoDados = new dblogEntities())
                {
                    var entregaSelecionado = from p in bancoDados.Tbl_Entregas
                                             where ((p.ID_Motoboy.Equals(intMotoboyId)) ||
                                                   (intMotoboyId == null))
                                             select p;

                    if (entregaSelecionado.Count() > 0)
                    {
                        foreach (Tbl_Entregas item in entregaSelecionado)
                        {
                            Tbl_Entregas novoItem = new Tbl_Entregas();

                            novoItem.ID_Motoboy = item.ID_Motoboy;
                            novoItem.ID_Cliente = item.ID_Cliente;
                            novoItem.Nome_Destinatario = item.Nome_Destinatario;
                            novoItem.Endereco = item.Endereco;
                            novoItem.Bairro = item.Bairro;
                            novoItem.Cidade = item.Cidade;
                            novoItem.Latitude = item.Latitude;
                            novoItem.Longitude = item.Longitude;

                            entregaColecao.Add(novoItem);
                        }
                    }
                }

                return entregaColecao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
