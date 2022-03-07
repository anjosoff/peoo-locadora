using System;
class Locadora {
  public int IdLocacao {get;set;}
  public int IdCliente{get;set;}
  public int IdCarro{get;set;}
  public override string ToString() {
    return $"ID da Locação {IdLocacao} - Id do Cliente {IdCliente} \n ID do Veículo{IdCarro}";
  }
  
}