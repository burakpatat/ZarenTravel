<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentResult.aspx.cs" Inherits="PAyment.UI.PaymentResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-lg-10 mb-3">
            <div class="row">
                <div class="col-8"></div>
                <div class="col-2 float-right">
                    <h5 class="fs-15px text-end">Ödeme başarıyla tamamlandı</h5>

                    <asp:Literal ID="ltrResult" runat="server"></asp:Literal>
                </div>
               
            </div>
        </div>
   
        </div>
</asp:Content>
