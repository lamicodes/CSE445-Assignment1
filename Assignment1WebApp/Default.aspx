<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment1WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment 1 Web Services</title>

    <style>
        body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #eef4ff, #f5f0ff, #fffaf2);
            color: #4b4b63;
        }

        .page-container {
            max-width: 900px;
            margin: 40px auto;
            padding: 20px;
        }

        .header-card {
            background: rgba(255, 255, 255, 0.85);
            border-radius: 24px;
            padding: 28px;
            box-shadow: 0 10px 25px rgba(120, 120, 170, 0.15);
            text-align: center;
            margin-bottom: 25px;
        }

        .header-card h1 {
            margin: 0;
            font-size: 34px;
            color: #5b6cb8;
        }

        .header-card p {
            margin-top: 10px;
            font-size: 16px;
            color: #7a7a95;
        }

        .card {
            background: rgba(255, 255, 255, 0.9);
            border-radius: 22px;
            padding: 25px;
            margin-bottom: 22px;
            box-shadow: 0 10px 25px rgba(120, 120, 170, 0.12);
        }

        .card h2 {
            margin-top: 0;
            color: #6f7bd8;
            font-size: 24px;
        }

        .section-subtitle {
            margin-bottom: 18px;
            color: #8a8aa8;
        }

        .input-row {
            margin-bottom: 18px;
        }

        .label-text {
            display: block;
            margin-bottom: 8px;
            font-weight: 600;
            color: #66668a;
        }

        .text-input {
            width: 260px;
            padding: 12px 14px;
            border: 1px solid #d9d9f2;
            border-radius: 14px;
            font-size: 15px;
            background: #fcfcff;
            outline: none;
        }

        .wide-input {
            width: 90%;
            max-width: 500px;
        }

        .btn {
            margin-top: 10px;
            padding: 11px 18px;
            border: none;
            border-radius: 14px;
            background: linear-gradient(135deg, #a7c7ff, #c9b6ff);
            color: white;
            font-size: 14px;
            font-weight: 600;
            cursor: pointer;
        }

        .btn:hover {
            opacity: 0.95;
        }

        .result-box {
            margin-top: 12px;
            padding: 12px 15px;
            background: #f8f6ff;
            border-radius: 14px;
            border: 1px solid #e6e1fb;
            min-height: 24px;
            color: #5c5c7b;
            font-weight: 600;
        }

        .mini-grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 18px;
        }

        @media (max-width: 700px) {
            .mini-grid {
                grid-template-columns: 1fr;
            }

            .text-input,
            .wide-input {
                width: 100%;
                max-width: 100%;
            }
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="page-container">

            <div class="header-card">
                <h1>☁️ Service Station</h1>
                <p>Soft little web app for temperature conversion and number sorting</p>
            </div>

            <div class="card">
                <h2>🌡 Temperature Converter</h2>
                <p class="section-subtitle">Convert between Celsius and Fahrenheit</p>

                <div class="mini-grid">
                    <div>
                        <div class="input-row">
                            <span class="label-text">Celsius</span>
                            <asp:TextBox ID="txtCelsius" runat="server" CssClass="text-input"></asp:TextBox>
                            <br />
                            <asp:Button
                                ID="btnCtoF"
                                runat="server"
                                Text="Convert to Fahrenheit"
                                CssClass="btn"
                                OnClick="btnCtoF_Click" />
                        </div>

                        <div class="result-box">
                            Result:
                            <asp:Label ID="lblFahrenheit" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div>
                        <div class="input-row">
                            <span class="label-text">Fahrenheit</span>
                            <asp:TextBox ID="txtFahrenheit" runat="server" CssClass="text-input"></asp:TextBox>
                            <br />
                            <asp:Button
                                ID="btnFtoC"
                                runat="server"
                                Text="Convert to Celsius"
                                CssClass="btn"
                                OnClick="btnFtoC_Click" />
                        </div>

                        <div class="result-box">
                            Result:
                            <asp:Label ID="lblCelsius" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card">
                <h2>🔢 Number Sorter</h2>
                <p class="section-subtitle">Enter comma-separated numbers and sort them in ascending order</p>

                <div class="input-row">
                    <span class="label-text">Comma-separated numbers</span>
                    <asp:TextBox ID="txtNumbers" runat="server" CssClass="text-input wide-input"></asp:TextBox>
                    <br />
                    <asp:Button
                        ID="btnSort"
                        runat="server"
                        Text="Sort Numbers"
                        CssClass="btn"
                        OnClick="btnSort_Click" />
                </div>

                <div class="result-box">
                    Sorted Result:
                    <asp:Label ID="lblSorted" runat="server" Text=""></asp:Label>
                </div>
            </div>

        </div>
    </form>
</body>
</html>