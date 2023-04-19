<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Async="true" EnableEventValidation="true" Inherits="PAyment.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <% if (paymentProcess != null && transactionDTO!=null && transactionDTO.CurrencyInfo!=null)
        { %>
    <div class="row ">
        <div class="col-xl-12 text-center col-sm-6 mb-3">
            <a class="d-inline-block" href="/">
                <img class="img-fluid h-50px" src="/Content/img/logo.png" /></a>
        </div>
    </div>

    <!-- BEGIN row -->
    <div class="row justify-content-center">
        <div class="col-lg-10 mb-3">
            <div class="row">
                <div class="col-8"></div>
                <div class="col-2 float-right">
                    <h5 class="fs-15px text-end">Ödenecek Tutar <%=transactionDTO.TotalAmount %> <%=transactionDTO.CurrencyInfo.CurrencyCode %>
                    </h5>
                </div>
                <div class="col-2 float-right">
                    <asp:DropDownList ClientIDMode="Static" ID="drLanguage" CssClass="form-select form-select-lg bg-white bg-opacity-5"
                        runat="server">
                        <asp:ListItem Text="TR" Value="1" />
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <!-- BEGIN col-3 -->
        <div class="col-xl-10">
            <!-- BEGIN card -->
            <div class="card mb-3">
                <!-- BEGIN card-body -->
                
                <div class="card-body">
                    <div class="row justify-content-center">
                        <div class="col-xl-12 mb-3">
                            <%

                                if (PageInfo != null && PageInfo != "" && PageInfo == "personal")
                                {%>
                            <div class="nav-wizards-container">
                                <nav class="nav nav-wizards-1 mb-2">
                                    <!-- active -->
                                    <div class="nav-item col">
                                        <a class="nav-link active" href="?page=personal&process=<%=Request.QueryString["process"] %>">
                                            <div class="nav-no">1</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Kişisel Bilgiler</div>
                                        </a>
                                    </div>
                                    <!-- disabled -->
                                    <div class="nav-item col">
                                        <a class="nav-link " href="?page=address&process=<%=Request.QueryString["process"] %>">
                                            <div class="nav-no">2</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Adres ve Fatura Bilgileri</div>
                                        </a>
                                    </div>

                                    <div class="nav-item col">
                                        <a class="nav-link " href="?page=cardinfo&process=<%=Request.QueryString["process"] %>">
                                            <div class="nav-no">3</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Kart Bilgileri</div>
                                        </a>
                                    </div>
                                </nav>
                            </div>
                            <% }
                                else if (PageInfo != null && PageInfo != "" && PageInfo == "address")
                                {%>
                            <div class="nav-wizards-container">
                                <nav class="nav nav-wizards-1 mb-2">


                                    <!-- active -->
                                    <div class="nav-item col">
                                        <a class="nav-link completed" href="?page=personal">
                                            <div class="nav-no">1</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Kişisel Bilgiler</div>
                                        </a>
                                    </div>

                                    <!-- disabled -->
                                    <div class="nav-item col">
                                        <a class="nav-link active" href="?page=address">
                                            <div class="nav-no">2</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Adres ve Fatura Bilgileri</div>
                                        </a>
                                    </div>

                                    <div class="nav-item col">
                                        <a class="nav-link " href="?page=cardinfo">
                                            <div class="nav-no">3</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Kart Bilgileri</div>
                                        </a>
                                    </div>
                                </nav>
                            </div>
                            <%}
                                else if (PageInfo != null && PageInfo != "" && PageInfo == "cardinfo")
                                {%>
                            <div class="nav-wizards-container">
                                <nav class="nav nav-wizards-1 mb-2">


                                    <!-- active -->
                                    <div class="nav-item col">
                                        <a class="nav-link completed" href="?page=personal">
                                            <div class="nav-no">1</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Kişisel Bilgiler</div>
                                        </a>
                                    </div>

                                    <!-- disabled -->
                                    <div class="nav-item col">
                                        <a class="nav-link completed" href="?page=address">
                                            <div class="nav-no">2</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Adres ve Fatura Bilgileri</div>
                                        </a>
                                    </div>

                                    <div class="nav-item col">
                                        <a class="nav-link active" href="?page=cardinfo">
                                            <div class="nav-no">3</div>
                                            <div class="nav-text nav-text d-none d-lg-block">Kart Bilgileri</div>
                                        </a>
                                    </div>
                                </nav>
                            </div>
                            <% 

                                }%>
                        </div>
                       
                        <div class="col-xl-12">
                            <%if (PageInfo != null && PageInfo != "" && PageInfo == "personal")
                                {%>
                            <div class="row justify-content-center">
                                <div class="col-xl-8">


                                    <div class="row justify-content-center">
                                        <div class="col-xl-8">
                                            <h4 class=" text-white text-center">Kişisel Bilgiler
                                            </h4>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">Ad/Soyad <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtNameSurname" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                              
                                            </div>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">E-Mail <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtEmail" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                           
                                            </div>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">Telefon <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtPhone" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                            
                                            </div>
                                            <div class="mb-3">
                                                <asp:Button Text="DEVAM" CssClass="btn btn-outline-theme btn-lg d-block w-100"
                                                    ClientIDMode="Static" ID="personalBtn" OnClick="personalBtn_Click" runat="server" />
                                                 
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                            <% }
                                else if (PageInfo != null && PageInfo != "" && PageInfo == "address")
                                {%>
                            <div class="row justify-content-center">
                                <div class="col-xl-8">

                                    <div class="row justify-content-center">
                                        <div class="col-xl-8 form-group">
                                            <h4 class=" text-white text-center">Adres ve Fatura Bilgileri
                                            </h4>
                                            <div class="mb-3">
                                                <label class="form-label">Adres<span class="text-danger">*</span></label> 
                                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" ClientIDMode="Static" Rows="3"
                                                    CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">Fatura Adresi<span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtTaxAddress" ClientIDMode="Static" TextMode="MultiLine" Rows="3"
                                                    CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox> 
                                            </div>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">İl<span class="text-danger">*</span></label>
                                              
                                                <asp:TextBox ID="txtCity" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">İlçe<span class="text-danger">*</span></label>
                                          
                                                <asp:TextBox ID="txtProvience" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">Firma Adı<span class="text-danger">*</span></label>
                                            
                                                <asp:TextBox ID="txtCompany" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                            </div>

                                            <div class="mb-3">
                                                <asp:Button Text="DEVAM"  CssClass="btn btn-outline-theme btn-lg d-block w-100"
                                                    ClientIDMode="Static" ID="btnAddress" OnClick="btnAddress_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <% }
                                else if (PageInfo != null && PageInfo != "" && PageInfo == "cardinfo")
                                {%>
                            <div class="row justify-content-center">
                                <div class="col-xl-8">

                                    <div class="row justify-content-center">
                                        <div class="col-xl-8 form-group">
                                            <h4 class=" text-white text-center">Kart Bilgileri
                                            </h4>
                                            <div class="mb-3">
                                                <label class="form-label">Kart üzerindeki İsim<span class="text-danger">*</span></label>
                                             
                                                <asp:TextBox ID="txtCardNameSurname" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="mb-3 form-group">
                                                <label class="form-label">Kart Numarası<span class="text-danger">*</span></label>
                                               
                                                <asp:TextBox ID="txtCardNumber" ClientIDMode="Static" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div class="mb-3">
                                                <div class="col-12">
                                                    <label class="form-label">Son Kullanma Tarihi (Ay)<span class="text-danger">*</span></label>
                                                    <asp:DropDownList ClientIDMode="Static" ID="drMonth" CssClass="form-select form-select-lg bg-white bg-opacity-5"
                                                        runat="server">
                                                        <asp:ListItem Text="1" Value="1" />
                                                        <asp:ListItem Text="2" Value="2" />
                                                        <asp:ListItem Text="3" Value="3" />
                                                        <asp:ListItem Text="4" Value="4" />
                                                        <asp:ListItem Text="5" Value="5" />
                                                        <asp:ListItem Text="6" Value="6" />
                                                        <asp:ListItem Text="7" Value="7" />
                                                        <asp:ListItem Text="8" Value="8" />
                                                        <asp:ListItem Text="9" Value="9" />
                                                        <asp:ListItem Text="10" Value="10" />
                                                        <asp:ListItem Text="11" Value="11" />
                                                        <asp:ListItem Text="12" Value="12" />
                                                    </asp:DropDownList>


                                                </div>
                                            

                                            </div>
                                            <div class="mb-3">
                                                <div class="col-12">
                                                    <label class="form-label">Son Kullanma Tarihi (Yıl)<span class="text-danger">*</span></label>
                                                    <asp:DropDownList ClientIDMode="Static" ID="drYear" CssClass="form-select form-select-lg bg-white bg-opacity-5"
                                                        runat="server">
                                                        <asp:ListItem Text="2023" Value="23" />
                                                        <asp:ListItem Text="2024" Value="24" />
                                                        <asp:ListItem Text="2025" Value="25" />
                                                        <asp:ListItem Text="2026" Value="26" />
                                                        <asp:ListItem Text="2027" Value="27" />
                                                        <asp:ListItem Text="2028" Value="28" />
                                                        <asp:ListItem Text="2029" Value="29" />
                                                        <asp:ListItem Text="2030" Value="30" />
                                                        <asp:ListItem Text="2031" Value="31" />
                                                        <asp:ListItem Text="2032" Value="32" />
                                                        <asp:ListItem Text="2033" Value="33" />
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            <div class="mb-3"> 
                                                    <div class="col-12">
                                                        <label class="form-label">Güvenlik Numarası (CVC)<span class="text-danger">*</span></label>
                                                        <asp:TextBox ClientIDMode="Static" ID="txtCVC" CssClass="form-control form-control-lg bg-white bg-opacity-5"
                                                            runat="server"></asp:TextBox> 
                                                    </div>
                                               
                                            </div>
                                          
                                            <div class="mb-3">
                                                <div class="form-check">  
                                                    <asp:CheckBox ClientIDMode="Static" ID="ch3D" Text="3D ÖDEME" runat="server" />
                                                </div>
                                            </div>
                                           
                                            <div class="mb-3">
                                                <div class="form-check">
                                                    <asp:CheckBox ID="chPolicy" ClientIDMode="Static" runat="server" />
                                                    <label class="form-check-label" for="chPolicy">
                                                        I have read and agree to the <a
                                                            href="#">Terms of Use</a> and <a href="#">Privacy Policy</a>.</label>
                                                  
                                                </div> 
                                            </div>
                                            <div class="mb-3">
                                                <asp:Button Text="ÖDEMEYİ TAMAMLA" CssClass="btn btn-outline-theme btn-lg d-block w-100"
                                                    ClientIDMode="Static" ID="paymentBtn" OnClick="paymentBtn_Click" runat="server" /> 
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <% }%>
                        </div>

                    </div>

                </div>
                <div class="card-arrow">
                    <div class="card-arrow-top-left"></div>
                    <div class="card-arrow-top-right"></div>
                    <div class="card-arrow-bottom-left"></div>
                    <div class="card-arrow-bottom-right"></div>
                </div>


            </div>

        </div>
        <!-- END card-body -->
        <!-- BEGIN card-arrow -->

        <!-- END card-arrow -->
    </div>
    <!-- END card -->
    <!-- END col-3 -->
    <!-- END row -->

    <asp:Literal ID="ltrToast" runat="server"></asp:Literal>
    <style>
        .nav.nav-tabs.nav-tabs-v2 > .nav-item > .nav-link {
            padding: 1rem 30px;
        }

        input#chPolicy {
    float: left;
    margin-top: 3px;
    margin-right: 8px;
}

        input#ch3D {
    float: left;
    margin-top: 3px;
    margin-right: 8px;
}

        .form-check-label{
            display:block;
        }
    </style>
    <%}
else { %>
    
    
    <%} %>
</asp:Content>
