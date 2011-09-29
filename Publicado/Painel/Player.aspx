<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Player.aspx.cs" Inherits="Bananas.Painel.Player"
  Theme="Player" %>

<!doctype html public "-//w3c//dtd xhtml 1.0 transitional//en" "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Player</title>
  <script src="../Scripts/gaia.js" type="text/javascript"></script>
  <script src="../Scripts/engate.js" type="text/javascript"></script>
  <script src="../Scripts/server-hour.js" type="text/javascript"></script>
  <script src="../Scripts/usuariosativos.js" type="text/javascript"></script>
  <script src="../Scripts/programa.js" type="text/javascript"></script>
  <script src="../Scripts/text-stream.js" type="text/javascript"></script>
  <script type="text/javascript">
    window.onload = function () {
      //Estrutura de engate/desengate ------------------                
      setLegenda($id("player-engate-desengate-legenda"));
      setContador($id("player-contador"));
      checkEng();

      //Sincornização com informações do servidor ------------------
      setRelogio($id("lHora"));
      syncServer();

      //Sincronização: Usuarios ativos
      setContainerUsuarios($id("ulContainerUsuarios"));
      syncUsuariosAtivos();

      //play audio
      setPlay($id("dPlayer"));
      playRadio();

      //Prepara quadro de comunicado
      setQuadroComunicados($id("dStreamComunicados"));
      checkMsg();

      //Prepara programacao
      setContainerPrograma($id("ulPrograma"));
      setContainerProgramacao($id("ulProgramacao"));
    };
  </script>
</head>
<body class="player-background">
  <form id="form1" runat="server">
  <div id="player-content">
    <div id="player-logout">
      <span id="player-logout-img"></span><span id="player-logout-lnk">
        <asp:LinkButton runat="server" ID="lnkLogOut" OnClick="lnkLogOut_Click" Text="Log Out"></asp:LinkButton>
      </span>
    </div>
    <div class="player-column">
      <div class="box-content">
        <span class="title">Hora Local</span> <span id="lHora">00:00:00</span>
      </div>
      <div class="box-content">
        <span class="title" id="player-engate-desengate-legenda">Situação:</span>
        <div id="player-contador">
          <span style="color: Red;">FORA</span></div>
      </div>
      <div class="box-content" id="dUsuariosLogados">
        <span class="title">Usuários Logados</span>
        <ul id="ulContainerUsuarios">
        </ul>
      </div>
    </div>
    <div class="player-column">
      <div id="player-logo">
      </div>
      <div class="box-content" id="dComunicados">
        <span class="titleComunicado">Comunicados</span>
        <div id="dStreamComunicados">
        </div>
      </div>
    </div>
    <div class="player-column">
      <ul class="lista-links">
        <li>audio 1</li>
        <li>audio 2</li>
      </ul>
      <div class="box-content" id="dPlayer">
      </div>
      <div class="box-content" id="dPrograma">
        <span class="title">Programa</span>
        <div id="ulPrograma">
        </div>
      </div>
      <div class="box-content" id="dProgramacao">
        <span class="title">Programação</span>
        <ul id="ulProgramacao" class="list-programacao">
        </ul>
      </div>
    </div>
  </div>
  </form>
</body>
</html>
