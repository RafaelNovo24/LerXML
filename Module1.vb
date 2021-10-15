Imports System.Linq
Imports System.Xml
Imports System.Text
Imports System.Threading.Tasks
Imports System
Imports System.Collections.Generic

Module Module1
    Dim filepath = ("C:\Users\Rafael Novo\Desktop\Empresas\Ãjudas\XmlUser\xmlTeste.xml")

    Sub Main()

        FazerPedido()
        Dim resposta As String = Console.ReadLine()

        If resposta = 1 Then
            filepath = "C:\Users\Rafael Novo\Desktop\Empresas\Ãjudas\XmlUser\exemplo_1_XML.xml"
            CarregarXml()

        ElseIf resposta = 2 Then
            filepath = "C:\Users\Rafael Novo\Desktop\Empresas\Ãjudas\XmlUser\exemplo_2_XML.xml"
            CarregarXml()
            LerListaNodes()
        ElseIf resposta = 3 Then
            filepath = "C:\Users\Rafael Novo\Desktop\Empresas\Ãjudas\XmlUser\exemplo_3_XML.xml"
            CarregarXml()
            LerListaNodesGasolina()
        Else
            Console.WriteLine("Resposta inválida")
            Console.Clear()
            FazerPedido()
        End If
    End Sub

    Private Sub FazerPedido()
        Console.WriteLine("Escolha o nome do ficheiro para dar upload:")
        Console.WriteLine("1. exemplo_1_XML")
        Console.WriteLine("2. exemplo_2_XML")
        Console.WriteLine("3. exemplo_3_XML")

    End Sub

    Private Sub CarregarXml()
        'Carregar ficheiro Xml e coloca na consola (atenção ao filepath)
        Dim xdoc As New XmlDocument
        xdoc.Load(filepath)
        xdoc.Save(Console.Out)
        Console.ReadLine()

    End Sub

    Private Sub AlterarSingleNode()
        ' com o XML exemplo_1_XML (alterar o filepath)
        Dim x As New XmlDocument
        x.Load(filepath)
        Dim node As XmlNode = x.SelectSingleNode("/peticionServicio/clasificacionDeCliente/nif")
        Console.WriteLine(node.InnerText)
        Console.ReadLine()
        x.Save(filepath)
    End Sub

    Private Sub LerListaNodes()

        ' com o XML exemplo_2_XML (alterar o filepath)

        Dim xdc As New XmlDocument()
        xdc.Load(filepath)

        Dim xNodesList As XmlNodeList = xdc.SelectNodes("command")

        'procura em todos os nodes dentro de "command"
        For Each xNode As XmlNode In xNodesList

            Dim element As XmlElement = CType(xNode, XmlElement)

            'node do "name" em todos os "command" || ir buscar apenas 1 node
            Dim name As String = Convert.ToString(xNode("Name").InnerText)

            'nodes das datas nos "command"
            Dim data1 As Integer
            Dim data2 As Integer
            Dim data3 As Integer

            data1 = Convert.ToInt32(element.GetElementsByTagName("data")(0).ChildNodes(0).InnerText)
            data2 = Convert.ToInt32(element.GetElementsByTagName("data")(0).ChildNodes(1).InnerText)
            data3 = Convert.ToInt32(element.GetElementsByTagName("data")(0).ChildNodes(2).InnerText)

            'nodes das rangeDatas nos "command"
            Dim rangeData1 As Integer
            Dim rangeData2 As Integer
            Dim rangeData3 As Integer

            rangeData1 = Convert.ToInt32(element.GetElementsByTagName("rangeData")(0).ChildNodes(0).InnerText)
            rangeData2 = Convert.ToInt32(element.GetElementsByTagName("rangeData")(0).ChildNodes(1).InnerText)
            rangeData3 = Convert.ToInt32(element.GetElementsByTagName("rangeData")(0).ChildNodes(2).InnerText)

            'atributos do node
            Dim atributo1 As String
            Dim atributo2 As String
            Dim atributo3 As String

            atributo1 = element.GetElementsByTagName("rangeData")(0).ChildNodes(0).Attributes("atributo").Value.ToString()
            atributo2 = element.GetElementsByTagName("rangeData")(0).ChildNodes(1).Attributes("atributo").Value.ToString()
            atributo3 = element.GetElementsByTagName("rangeData")(0).ChildNodes(2).Attributes("atributo").Value.ToString()

            'escreve resultados
            Console.WriteLine(data1)
            Console.WriteLine(data2)
            Console.WriteLine(data3)

            Console.WriteLine(rangeData1)
            Console.WriteLine(rangeData2)
            Console.WriteLine(rangeData3)

            Console.WriteLine(atributo1)
            Console.WriteLine(atributo2)
            Console.WriteLine(atributo3)

            Console.ReadLine()
        Next
    End Sub

    Private Sub LerListaNodesGasolina()

        ' com o XML exemplo_2_XML (alterar o filepath)

        Dim xdc As New XmlDocument()
        xdc.Load(filepath)

        Dim posto As String
        Dim nodeTransac As XmlNode = xdc.SelectSingleNode("/Transaction")

        posto = nodeTransac.Attributes("SiteID")(0).Value.ToString()


        'Dim nodeListHeader As XmlNodeList = xdc.SelectNodes("IXHeader")

        'For Each node As XmlNode In nodeListHeader
        '    Dim data As String
        '    Dim precUnit As String
        '    Dim litrosTotal As Decimal
        '    Dim valorTotal As Decimal
        '    Dim dataHoje As DateTime
        '    Dim element As XmlElement = CType(node, XmlElement)

        '    data = element.GetElementsByTagName("HE_NORMAL")(0).ChildNodes(0).Attributes("TicketDateTime").Value.ToString()



        'Next


        ''procura em todos os nodes dentro de "command"
        'For Each xNode As XmlNode In xNodesList

        '    Dim element As XmlElement = CType(xNode, XmlElement)

        '    'node do "name" em todos os "command" || ir buscar apenas 1 node
        '    Dim name As String = Convert.ToString(xNode("Name").InnerText)

        '    'nodes das datas nos "command"
        '    Dim data1 As Integer
        '    Dim data2 As Integer
        '    Dim data3 As Integer

        '    data1 = Convert.ToInt32(element.GetElementsByTagName("data")(0).ChildNodes(0).InnerText)
        '    data2 = Convert.ToInt32(element.GetElementsByTagName("data")(0).ChildNodes(1).InnerText)
        '    data3 = Convert.ToInt32(element.GetElementsByTagName("data")(0).ChildNodes(2).InnerText)

        '    'nodes das rangeDatas nos "command"
        '    Dim rangeData1 As Integer
        '    Dim rangeData2 As Integer
        '    Dim rangeData3 As Integer

        '    rangeData1 = Convert.ToInt32(element.GetElementsByTagName("rangeData")(0).ChildNodes(0).InnerText)
        '    rangeData2 = Convert.ToInt32(element.GetElementsByTagName("rangeData")(0).ChildNodes(1).InnerText)
        '    rangeData3 = Convert.ToInt32(element.GetElementsByTagName("rangeData")(0).ChildNodes(2).InnerText)

        '    'atributos do node
        '    Dim atributo1 As String
        '    Dim atributo2 As String
        '    Dim atributo3 As String

        '    atributo1 = element.GetElementsByTagName("rangeData")(0).ChildNodes(0).Attributes("atributo").Value.ToString()
        '    atributo2 = element.GetElementsByTagName("rangeData")(0).ChildNodes(1).Attributes("atributo").Value.ToString()
        '    atributo3 = element.GetElementsByTagName("rangeData")(0).ChildNodes(2).Attributes("atributo").Value.ToString()

        '    'escreve resultados
        '    Console.WriteLine(data1)
        '    Console.WriteLine(data2)
        '    Console.WriteLine(data3)

        '    Console.WriteLine(rangeData1)
        '    Console.WriteLine(rangeData2)
        '    Console.WriteLine(rangeData3)

        '    Console.WriteLine(atributo1)
        '    Console.WriteLine(atributo2)
        '    Console.WriteLine(atributo3)

        Console.ReadLine()
        'Next
    End Sub

End Module
