﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test_noMaster.aspx.cs" Inherits="test_noMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


</head>
<body>
    <style>
        .spinner {
            width: 30px;
            height: 30px;
            background-color: #333;
            margin: 100px auto;
            -webkit-animation: rotateplane 1.2s infinite ease-in-out;
            animation: rotateplane 1.2s infinite ease-in-out;
        }

        @-webkit-keyframes rotateplane {
            0% {
                -webkit-transform: perspective(120px);
            }

            50% {
                -webkit-transform: perspective(120px) rotateY(180deg);
            }

            100% {
                -webkit-transform: perspective(120px) rotateY(180deg) rotateX(180deg);
            }
        }

        @keyframes rotateplane {
            0% {
                transform: perspective(120px) rotateX(0deg) rotateY(0deg);
                -webkit-transform: perspective(120px) rotateX(0deg) rotateY(0deg);
            }

            50% {
                transform: perspective(120px) rotateX(-180.1deg) rotateY(0deg);
                -webkit-transform: perspective(120px) rotateX(-180.1deg) rotateY(0deg);
            }

            100% {
                transform: perspective(120px) rotateX(-180deg) rotateY(-179.9deg);
                -webkit-transform: perspective(120px) rotateX(-180deg) rotateY(-179.9deg);
            }
        }
    </style>
    <div class="spinner"></div>
</body>
</html>