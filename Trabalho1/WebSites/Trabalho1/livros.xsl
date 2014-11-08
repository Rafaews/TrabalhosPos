<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">

    <xsl:template match="/">
      <html>
        <body>
          <h2>Livros</h2>
          <table border="1">
            <tr bgcolor="00FFFF" align="center">
              <td><b>Título</b></td>
              <td><b>Autor</b></td>
              <td><b>Editora</b></td>
            </tr>
          <xsl:for-each select="livros/livro">
            <tr align="center">
              <td><xsl:value-of select="titulo"/></td>
              <td><xsl:value-of select="autor"/></td>
              <td><xsl:value-of select="editora"/></td>
            </tr>
          </xsl:for-each>
          </table>
        </body>
      </html>
    </xsl:template>
</xsl:stylesheet>
