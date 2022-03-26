using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Xml.Serialization;
using System.IO;
class Sistema{
  private static Veiculo[] veiculos = new Veiculo[10]; 
  private static int nVeiculos;
  private static List<Locacao> locacoes = new List<Locacao>();
  private static List<Cliente> clientes = new List<Cliente>();

/*
   FUNÇÕES DA CLASSE VEICULO  
*/

  public static void VeiculoInserir(Veiculo obj){
    if(nVeiculos == veiculos.Length)
      Array.Resize(ref veiculos, 2 * veiculos.Length);
    veiculos[nVeiculos]=obj;
    nVeiculos++;
  }
  public static Veiculo[] VeiculoListar(){
    Veiculo[] aux= new Veiculo[nVeiculos];
    Array.Copy(veiculos, aux, nVeiculos);
    return aux;
  }
  public static Veiculo VeiculoListar(int id){
    foreach(Veiculo obj in veiculos)
      if(obj != null && obj.GetIdVeiculo()==id) return obj;
    return null;
  }
  public static void VeiculoAtualizar(Veiculo obj){
    Veiculo aux= VeiculoListar(obj.GetIdVeiculo());
    if(aux!=null)
      aux.SetModelo(obj.GetModelo());
      aux.SetPlaca(obj.GetPlaca());
  }
  public static void VeiculoExcluir(Veiculo obj){
    int aux=VeiculoIndice(obj.GetIdVeiculo());
    
    if(aux!=-1)
      for(int i=aux; i<nVeiculos -1; i++)
        veiculos[i]=veiculos[i+1];
    nVeiculos--;
  }
  public static int VeiculoIndice(int id){
    for(int i=0; i<nVeiculos;i++){
      Veiculo obj = veiculos[i];
      if(obj.GetIdVeiculo()==id) return i;
    }
    return -1;
  }

/*
   FUNÇÕE DA CLASSE CLIENTE 
*/

public static void ClienteInserir(Cliente obj) {
    int id = 0;
    foreach(Cliente aux in clientes)
      if (aux.IdCliente > id) id = aux.IdCliente;
    obj.IdCliente = id + 1;  
    clientes.Add(obj);
  }
  public static List<Cliente> ClienteListar() {
    clientes.Sort();
    return clientes;
  }
  public static Cliente ClienteListar(int id) {
    foreach(Cliente obj in clientes)
      if (obj.IdCliente == id) return obj;
    return null;  
  }
  public static void ClienteAtualizar(Cliente obj) {
    Cliente aux = ClienteListar(obj.IdCliente);
    if (aux != null) {
      aux.Nome = obj.Nome;
      aux.Cpf=obj.Cpf;
      aux.Email=obj.Email;
    }  
  }
  public static void ClienteExcluir(Cliente obj) {
    Cliente aux = ClienteListar(obj.IdCliente);
    if (aux != null) clientes.Remove(aux);
  }

/*
    FUNÇÕE DA CLASSE LOCADORA
*/
  
  public static void LocacaoInserir(Locacao obj) {
    int id = 0;
    foreach(Locacao aux in locacoes)
      if (aux.IdLocacao > id) id = aux.IdLocacao;
    obj.IdLocacao = id + 1;  
    locacoes.Add(obj);
  }
  public static List<Locacao> LocacaoListar() {
    return locacoes;
  }
  public static List<Locacao> LocacaoListar(Cliente cliente) {   
    List<Locacao> loc=new List<Locacao>();
    foreach(Locacao obj in locacoes)
      if (obj.IdCliente == cliente.IdCliente) 
        loc.Add(obj);
    return loc;  
  }
  public static Locacao LocacaoListar(int id) {
    foreach(Locacao obj in locacoes)
      if (obj.IdLocacao == id) return obj;
    return null;  
  }
  public static void LocacaoAtualizar(Locacao obj) {
    Locacao aux = LocacaoListar(obj.IdLocacao);
    if (aux != null) {
      aux.IdCliente=obj.IdCliente;
      aux.IdVeiculo=obj.IdVeiculo;
      aux.Dretira=obj.Dretira;
      aux.Ddevolve=obj.Ddevolve;
    }
  }
  public static void LocacaoExcluir(Locacao obj) {
    Locacao aux = LocacaoListar(obj.IdLocacao);
    if (aux != null) locacoes.Remove(aux);
  }
  public static void ToXML() {
    //locadora
    XmlSerializer xml = new XmlSerializer(typeof(List<Locacao>));
    StreamWriter f = new StreamWriter("./banco de dados/locacao.xml");
    xml.Serialize(f, locacoes);
    f.Close();

    //veiculo
    XmlSerializer xml1 = new XmlSerializer(typeof(List<Cliente>));
    StreamWriter f1 = new StreamWriter("./banco de dados/clientes.xml");
    xml1.Serialize(f1, clientes);
    f1.Close();
    
    //clientes
    XmlSerializer xml2 = new XmlSerializer(typeof(Veiculo[]));
    StreamWriter f2 = new StreamWriter("./banco de dados/veiculo.xml");
    xml2.Serialize(f2, VeiculoListar());
    f2.Close();
  }

  public static void FromXML() {
    //locadora
    XmlSerializer xml = new XmlSerializer(typeof(List<Locacao>));
    StreamReader f = new StreamReader("./banco de dados/locacao.xml");
    locacoes = (List<Locacao>)xml.Deserialize(f);
    f.Close();
    // veiculo
    XmlSerializer xml1 = new XmlSerializer(typeof(Veiculo[]));
    StreamReader f1 = new StreamReader("./banco de dados/veiculo.xml");
    veiculos = (Veiculo[])xml1.Deserialize(f1);
    f1.Close();

    //cliente
    XmlSerializer xml2 = new XmlSerializer(typeof(List<Cliente>));
    StreamReader f2 = new StreamReader("./banco de dados/clientes.xml");
    clientes = (List<Cliente>)xml2.Deserialize(f2);
    f2.Close();
    Console.WriteLine("\n Dados recuperados com sucesso!");
  }
}