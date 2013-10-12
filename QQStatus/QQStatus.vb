Public Enum StatusType
    Playing = 65541
    QQMusic = 65542
End Enum
Public Class QQStatus
    Dim pusher As Object
    Public Sub New()
        pusher = CreateObject("QQCPHelper.CPAdder")
    End Sub
    ''' <summary>
    ''' 推送指定类型消息到QQ
    ''' </summary>
    ''' <param name="uin">QQ号码</param>
    ''' <param name="type">推送类型ID</param>
    ''' <param name="msg">消息内容</param>
    ''' <param name="param">附加参数</param>
    ''' <remarks></remarks>
    Public Sub Push(ByVal uin As Integer, ByVal type As StatusType, ByVal msg As String, ByVal param As String)
        pusher.PutRSInfo(uin, type, msg, param)
    End Sub
    ''' <summary>
    ''' 发送QQ音乐状态
    ''' </summary>
    ''' <param name="uin">QQ号码</param>
    ''' <param name="msg">状态内容</param>
    ''' <param name="param">附加参数</param>
    ''' <remarks></remarks>
    Public Sub PushMusic(ByVal uin As Integer, ByVal msg As String, ByVal param As String)
        pusher.PutRSInfo(uin, StatusType.QQMusic, msg, param)
    End Sub
    ''' <summary>
    ''' 发送游戏中状态
    ''' </summary>
    ''' <param name="uin">QQ号码</param>
    ''' <param name="msg">状态内容</param>
    ''' <param name="param">附加参数</param>
    ''' <remarks></remarks>
    Public Sub PushGame(ByVal uin As Integer, ByVal msg As String, ByVal param As String)
        pusher.PutRSInfo(uin, StatusType.Playing, msg, param)
    End Sub
End Class
