'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
    End Sub
    Function IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC(ByVal ATE_NUM As String,
                                                 ByVal ID_PACIENTE As Integer,
                                                 ByVal ID_USUARIO As Integer,
                                                 ByVal ATE_FUR As Date,
                                                 ByVal ID_PROCE As Integer,
                                                 ByVal ID_ORDEN As Integer,
                                                 ByVal ID_TP_PACI As Integer,
                                                 ByVal ID_DOCTOR As Integer,
                                                 ByVal ID_PREVE As Integer,
                                                 ByVal ID_LOCAL As Integer,
                                                 ByVal ID_ESTADO As Integer,
                                                 ByVal ATE_OBS As String,
                                                 ByVal ATE_CAMA As String,
                                                 ByVal ATE_AÑO As Integer,
                                                 ByVal ATE_MES As Integer,
                                                 ByVal ATE_DIA As Integer,
                                                 ByVal ATE_TOTAL As Integer,
                                                 ByVal ATE_TOTAL_PREVI As Integer,
                                                 ByVal ATE_TOTAL_COPA As Integer,
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal Diag As String,
                                                 ByVal Diag2 As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, Diag, Diag2, xHora)

    End Function


    Function IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(ByVal ATE_NUM As String,
                                                 ByVal ID_PACIENTE As Integer,
                                                 ByVal ID_USUARIO As Integer,
                                                 ByVal ATE_FUR As Date,
                                                 ByVal ID_PROCE As Integer,
                                                 ByVal ID_ORDEN As Integer,
                                                 ByVal ID_TP_PACI As Integer,
                                                 ByVal ID_DOCTOR As Integer,
                                                 ByVal ID_PREVE As Integer,
                                                 ByVal ID_LOCAL As Integer,
                                                 ByVal ID_ESTADO As Integer,
                                                 ByVal ATE_OBS As String,
                                                 ByVal ATE_CAMA As String,
                                                 ByVal ATE_AÑO As Integer,
                                                 ByVal ATE_MES As Integer,
                                                 ByVal ATE_DIA As Integer,
                                                 ByVal ATE_TOTAL As Integer,
                                                 ByVal ATE_TOTAL_PREVI As Integer,
                                                 ByVal ATE_TOTAL_COPA As Integer,
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal Diag As String,
                                                 ByVal Diag2 As String,
                                                     ByVal SUB_ATENCION As String,
                                                     ByVal vih As String,
                                                     ByVal dni As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, Diag, Diag2, SUB_ATENCION, vih, dni, xHora)

    End Function


    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(ByVal ATE_NUM As String,
                                                 ByVal ID_PACIENTE As Integer,
                                                 ByVal ID_USUARIO As Integer,
                                                 ByVal ATE_FUR As Date,
                                                 ByVal ID_PROCE As Integer,
                                                 ByVal ID_ORDEN As Integer,
                                                 ByVal ID_TP_PACI As Integer,
                                                 ByVal ID_DOCTOR As Integer,
                                                 ByVal ID_PREVE As Integer,
                                                 ByVal ID_LOCAL As Integer,
                                                 ByVal ID_ESTADO As Integer,
                                                 ByVal ATE_OBS As String,
                                                 ByVal ATE_CAMA As String,
                                                 ByVal ATE_AÑO As Integer,
                                                 ByVal ATE_MES As Integer,
                                                 ByVal ATE_DIA As Integer,
                                                 ByVal ATE_TOTAL As Integer,
                                                 ByVal ATE_TOTAL_PREVI As Integer,
                                                 ByVal ATE_TOTAL_COPA As Integer,
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal ATE_SAYDEX As String,
                                                 ByVal DIAG1 As Integer,
                                                 ByVal DIAG2 As Integer,
                                                 ByVal sub_atencion As String, ByVal vih As String, ByVal Sub_prgrama As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, ATE_SAYDEX, DIAG1, DIAG2, sub_atencion, vih, Sub_prgrama, xHora)

    End Function

    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_SAYDEX_NEW(ByVal ATE_NUM As String,
                                                 ByVal ID_PACIENTE As Integer,
                                                 ByVal ID_USUARIO As Integer,
                                                 ByVal ATE_FUR As Date,
                                                 ByVal ID_PROCE As Integer,
                                                 ByVal ID_ORDEN As Integer,
                                                 ByVal ID_TP_PACI As Integer,
                                                 ByVal ID_DOCTOR As Integer,
                                                 ByVal ID_PREVE As Integer,
                                                 ByVal ID_LOCAL As Integer,
                                                 ByVal ID_ESTADO As Integer,
                                                 ByVal ATE_OBS As String,
                                                 ByVal ATE_CAMA As String,
                                                 ByVal ATE_AÑO As Integer,
                                                 ByVal ATE_MES As Integer,
                                                 ByVal ATE_DIA As Integer,
                                                 ByVal ATE_TOTAL As Integer,
                                                 ByVal ATE_TOTAL_PREVI As Integer,
                                                 ByVal ATE_TOTAL_COPA As Integer,
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal ATE_SAYDEX As String,
                                                 ByVal DIAG1 As Integer,
                                                 ByVal DIAG2 As Integer,
                                                      ByVal sub_atencion As String, ByVal vih As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_SAYDEX_NEW(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, ATE_SAYDEX, DIAG1, DIAG2, sub_atencion, vih, xHora)

    End Function

    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS(ByVal ATE_NUM As String,
                                                 ByVal ID_PACIENTE As Integer,
                                                 ByVal ID_USUARIO As Integer,
                                                 ByVal ATE_FUR As Date,
                                                 ByVal ID_PROCE As Integer,
                                                 ByVal ID_ORDEN As Integer,
                                                 ByVal ID_TP_PACI As Integer,
                                                 ByVal ID_DOCTOR As Integer,
                                                 ByVal ID_PREVE As Integer,
                                                 ByVal ID_LOCAL As Integer,
                                                 ByVal ID_ESTADO As Integer,
                                                 ByVal ATE_OBS As String,
                                                 ByVal ATE_CAMA As String,
                                                 ByVal ATE_AÑO As Integer,
                                                 ByVal ATE_MES As Integer,
                                                 ByVal ATE_DIA As Integer,
                                                 ByVal ATE_TOTAL As Integer,
                                                 ByVal ATE_TOTAL_PREVI As Integer,
                                                 ByVal ATE_TOTAL_COPA As Integer,
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal ATE_SAYDEX As String,
                                                 ByVal DIAG1 As Integer,
                                                 ByVal DIAG2 As Integer,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, ATE_SAYDEX, DIAG1, DIAG2, xHora)

    End Function
    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_OMI_NEW(ByVal ATE_NUM As String,
                                                 ByVal ID_PACIENTE As Integer,
                                                 ByVal ID_USUARIO As Integer,
                                                 ByVal ATE_FUR As Date,
                                                 ByVal ID_PROCE As Integer,
                                                 ByVal ID_ORDEN As Integer,
                                                 ByVal ID_TP_PACI As Integer,
                                                 ByVal ID_DOCTOR As Integer,
                                                 ByVal ID_PREVE As Integer,
                                                 ByVal ID_LOCAL As Integer,
                                                 ByVal ID_ESTADO As Integer,
                                                 ByVal ATE_OBS As String,
                                                 ByVal ATE_CAMA As String,
                                                 ByVal ATE_AÑO As Integer,
                                                 ByVal ATE_MES As Integer,
                                                 ByVal ATE_DIA As Integer,
                                                 ByVal ATE_TOTAL As Integer,
                                                 ByVal ATE_TOTAL_PREVI As Integer,
                                                 ByVal ATE_TOTAL_COPA As Integer,
                                                 ByVal PREI_FECHA_PRE As Date,
                                                 ByVal PROGRAMA As Integer,
                                                 ByVal SECTOR As Integer,
                                                 ByVal ATE_SAYDEX As String,
                                                 ByVal DIAG1 As Integer,
                                                 ByVal DIAG2 As Integer,
                                                      ByVal sub_atencion As String, ByVal vih As String,
                                                 Optional ByVal xHora As String = "00:00") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_OMI_NEW(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, ATE_SAYDEX, DIAG1, DIAG2, sub_atencion, vih, xHora)

    End Function
    Function IRIS_WEBF_CMVM_GRABA_PREINGRESO3_PRO_SEC_SIDRA_3_NEW(
                                                  ByVal ATE_NUM As String,'1
                                             ByVal ID_PACIENTE As Integer,'2
                                             ByVal ID_USUARIO As Integer,'3
                                             ByVal ATE_FUR As Date,'4
                                             ByVal ID_PROCE As Integer,'5
                                             ByVal ID_ORDEN As Integer,'6
                                             ByVal ID_TP_PACI As Integer,'7
                                             ByVal ID_DOCTOR As Integer,'8
                                             ByVal ID_PREVE As Integer,'9
                                             ByVal ID_LOCAL As Integer,'10
                                             ByVal ID_ESTADO As Integer,'11
                                             ByVal ATE_OBS As String,'12
                                             ByVal ATE_CAMA As String,'13
                                             ByVal ATE_AÑO As Integer,'14
                                             ByVal ATE_MES As Integer,'15
                                             ByVal ATE_DIA As Integer,'16
                                             ByVal ATE_TOTAL As Integer,' 17
                                             ByVal ATE_TOTAL_PREVI As Integer,'18
                                             ByVal ATE_TOTAL_COPA As Integer,'19
                                             ByVal PREI_FECHA_PRE As Date,'20
                                             ByVal PROGRAMA As Integer,'21
                                             ByVal SECTOR As Integer,'22
                                             ByVal ATE_SAYDEX As String,'23
                                             ByVal DIAG1 As Integer,'24
                                             ByVal DIAG2 As Integer,'25
                                             ByVal sub_atencion As String,'26
                                              ByVal vih As String,'27
                                              ByVal Sub_prgrama As String,'28
                                              ByVal ID_HORARIO As Integer,'29
                                              ByVal VAL_CLOCK As String) As Integer '30
        Return DD_Data.IRIS_WEBF_CMVM_GRABA_PREINGRESO3_PRO_SEC_SIDRA_3_NEW(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, ATE_SAYDEX, DIAG1, DIAG2, sub_atencion, vih, Sub_prgrama, ID_HORARIO, VAL_CLOCK)

    End Function
    Function IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW_CAJA(ByVal ATE_NUM As String,
                                               ByVal ID_PACIENTE As Integer,
                                               ByVal ID_USUARIO As Integer,
                                               ByVal ATE_FUR As Date,
                                               ByVal ID_PROCE As Integer,
                                               ByVal ID_ORDEN As Integer,
                                               ByVal ID_TP_PACI As Integer,
                                               ByVal ID_DOCTOR As Integer,
                                               ByVal ID_PREVE As Integer,
                                               ByVal ID_LOCAL As Integer,
                                               ByVal ID_ESTADO As Integer,
                                               ByVal ATE_OBS As String,
                                               ByVal ATE_CAMA As String,
                                               ByVal ATE_AÑO As Integer,
                                               ByVal ATE_MES As Integer,
                                               ByVal ATE_DIA As Integer,
                                               ByVal ATE_TOTAL As Integer,
                                               ByVal ATE_TOTAL_PREVI As Integer,
                                               ByVal ATE_TOTAL_COPA As Integer,
                                               ByVal PREI_FECHA_PRE As Date,
                                               ByVal PROGRAMA As Integer,
                                               ByVal SECTOR As Integer,
                                               ByVal ATE_SAYDEX As String,
                                               ByVal DIAG1 As Integer,
                                               ByVal DIAG2 As Integer,
                                               ByVal sub_atencion As String, ByVal vih As String,
                                               Optional ByVal xHora As String = "00:00") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW_CAJA(ATE_NUM,
                                                           ID_PACIENTE,
                                                           ID_USUARIO,
                                                           ATE_FUR,
                                                           ID_PROCE,
                                                           ID_ORDEN,
                                                           ID_TP_PACI,
                                                           ID_DOCTOR,
                                                           ID_PREVE,
                                                           ID_LOCAL,
                                                           ID_ESTADO,
                                                           ATE_OBS,
                                                           ATE_CAMA,
                                                           ATE_AÑO,
                                                           ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE, PROGRAMA, SECTOR, ATE_SAYDEX, DIAG1, DIAG2, sub_atencion, vih, xHora)

    End Function

End Class