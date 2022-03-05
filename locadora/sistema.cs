using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
class Sistema{
  private static Veiculo[] veiculos = new Veiculo[10]; 
  private static int nVeiculos;
  private static List<Locadora> locadoras = new List<Locadora>();
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
      if(obj != null && obj.GetIdCarro()==id) return obj;
    return null;
  }
  public static void VeiculoAtualizar(Veiculo obj){
    Veiculo aux= VeiculoListar(obj.GetIdCarro());
    if(aux!=null)
      aux.SetModelo(obj.GetModelo());
      aux.SetPlaca(obj.GetPlaca());
  }
  public static void VeiculoExcluir(Veiculo obj){
    int aux=VeiculoIndice(obj.GetIdCarro());
    
    if(aux!=-1)
      for(int i=aux; i<nVeiculos -1; i++)
        veiculos[i]=veiculos[i+1];
    nVeiculos--;
  }
  public static int VeiculoIndice(int id){
    for(int i=0; i<nVeiculos;i++){
      Veiculo obj = veiculos[i];
      if(obj.GetIdCarro()==id) return i;
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
  
  public static void LocadoraInserir(Locadora obj) {
    int id = 0;
    foreach(Locadora aux in locadoras)
      if (aux.IdLocacao > id) id = aux.IdLocacao;
    obj.IdLocacao = id + 1;  
    locadoras.Add(obj);
  }
  public static List<Locadora> LocadoraListar() {
    return locadoras;
  }
  public static List<Locadora> LocadoraListar(Cliente cliente) {   
    List<Locadora> loc=new List<Locadora>();
    foreach(Locadora obj in locadoras)
      if (obj.IdCliente == cliente.IdCliente) 
        loc.Add(obj);
    return loc;  
  }
  public static Locadora LocadoraListar(int id) {
    foreach(Locadora obj in locadoras)
      if (obj.IdLocacao == id) return obj;
    return null;  
  }
  public static void LocadoraAtualizar(Locadora obj) {
    Locadora aux = LocadoraListar(obj.IdLocacao);
    if (aux != null) {
      aux.IdCliente=obj.IdCliente;
      aux.IdCarro=obj.IdCarro;
    }
  }
  public static void LocadoraExcluir(Locadora obj) {
    Locadora aux = LocadoraListar(obj.IdLocacao);
    if (aux != null) locadoras.Remove(aux);
  }
}