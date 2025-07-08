using System;
@model LojaDeTenis.Models.Pedido

@{
    ViewData["Title"] = "Create";
}

< h1 > Create </ h1 >

< h4 > Pedido </ h4 >
< hr />
< div class= "row" >
    < div class= "col-md-4" >
        < form asp - action = "Create" method = "post" > < !--Corrigido erro de ortografia: "form" é uma palavra válida -->  
            <div asp-validation-summary="ModelOnly" class= "text-danger" ></ div >

            < div class= "form-group" >
                < label asp -for= "Data" class= "control-label" ></ label > < !--Corrigido erro de ortografia: "control" é uma palavra válida -->  
                <input asp-for="Data" class= "form-control" type = "date" />
                < span asp - validation -for= "Data" class= "text-danger" ></ span >
            </ div >

            < div class= "form-group" >
                < label asp -for= "ClienteId" class= "control-label" > Cliente </ label >
                < select asp -for= "ClienteId" class= "form-control" asp - items = "ViewBag.Clientes" >
                    < option value = "" > --Selecione um cliente --</option>  
                </select>  
                <span asp-validation-for="ClienteId" class= "text-danger" ></ span >
            </ div >

            < div class= "form-group" >
                < label asp -for= "CategoriaId" class= "control-label" > Categoria </ label >
                < select asp -for= "CategoriaId" class= "form-control" asp - items = "ViewBag.Categorias" >
                    < option value = "" > --Selecione uma categoria --</option>  
                </select>  
                <span asp-validation-for="CategoriaId" class= "text-danger" ></ span >
            </ div >

            < div class= "form-group" >
                < label asp -for= "Status" class= "control-label" ></ label >
                < input asp -for= "Status" class= "form-control" />
                < span asp - validation -for= "Status" class= "text-danger" ></ span >
            </ div >

            < div class= "form-group" >
                < input type = "submit" value = "Create" class= "btn btn-primary" />
            </ div >
        </ form >
    </ div >
</ div >

< div >
    < a asp - action = "Index" > Back to List</a>
</div>  

@section Scripts {  
    @{  
        await Html.RenderPartialAsync("_ValidationScriptsPartial");  
    }  
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaDeTenis.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public int CategoriaId { get; set; }  
        public string Status { get; set; }
    }
}
