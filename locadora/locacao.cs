using System;
using System.Collections.Generic;
public class Locacao: IComparable<Locacao>{
  public int IdLocacao {get;set;}
  public int IdCliente{get;set;}
  public int IdVeiculo{get;set;}  
  public DateTime Dretira{get;set;}
  public DateTime Ddevolve{get;set;}
  public int CompareTo(Locacao obj){
    return Dretira.CompareTo(obj.Dretira);
  }
}