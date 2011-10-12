namespace DotNetDev.Mvc.FSharp.ViewModels

// A basic F# class with string property
type Message = 
  val Text : string
  new(text) = { Text = text }    