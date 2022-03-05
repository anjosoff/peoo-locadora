using System;
class Locadora {
  public int IdLocacao {get;set;}
  public int IdCliente{get;set;}
  public int IdCarro{get;set;}
  public override string ToString() {
    return $"{IdLocacao} - {IdCliente}/n{IdCarro}";
  }
  
}