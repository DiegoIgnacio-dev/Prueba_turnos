
<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%>
<!--#include file ="ConexionIRIS.asp" -->
<!--#include file="rutinas.asp" -->

<%
	Set rst_BM3 = Server.CreateObject("ADODB.Recordset")
	Set rst_BM33 = Server.CreateObject("ADODB.Recordset")	
	Set rst_BM4 = Server.CreateObject("ADODB.Recordset")	
	Set rst_BM5 = Server.CreateObject("ADODB.Recordset")
	Set rst_BM6 = Server.CreateObject("ADODB.Recordset")	
	SET rst_BM_HORA = Server.CreateObject("ADODB.Recordset")	
	oid_empresa = Request.querystring("id_cliente")	
	session("ID_ATEN") =  oid_empresa	
	ID_USUARIO_WEB = session("WID_USUARIO")	
	ID_PERFIL_NUEVO_REAL = Request.querystring("ID_PERFIL_NUEVO")
	

		
%>

<%
	Dim Filename
	Dim Pdf, Doc, Page
	'IRISLABWEB_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA
	dim w_ID_PERFIL(50), w_IMP_SOLA(50), w_IMP_NOMBREPERF(50), w_Listo(50), w_ID_CF(50), w_NOMBRE_CF(50),cont_, contLINEA_, w_SECC_DESC(50), w_USU_NIC(50), w_NOMBRE_USU(50)
	
	DIM DATO_TITU, Activa_Linea_Resultado, w_SECC_DESC_WW, w_USU_NIC_WW
	Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
 	'set rst_BM3 = connBM3.execute("IRISLABWEB_GRABA_IMPRESION_FOLIO '"&Id_atencion_&"', '"& ID_USUARIO_WEB &"'  ")	

 	set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA2 '"&Id_atencion_&"', '"& ID_PERFIL_NUEVO_REAL &"' ")	
	cont_ = 1
	w_SECC_DESC_WW =""
	while not rst_BM3.eof
		w_ID_PERFIL(cont_) = rst_BM3("ID_PER") 
		w_ID_CF(cont_) = rst_BM3("ID_CODIGO_FONASA") 		
		w_IMP_SOLA(cont_) = rst_BM3("CF_IMP_SOLA") 		
		w_IMP_NOMBREPERF(cont_) = rst_BM3("CF_IMP_NOM_PER")
		w_NOMBRE_CF(cont_) = rst_BM3("CF_DESC")		
		w_Listo(cont_)= rst_BM3("ATE_DET_IMPRIME") 
		w_SECC_DESC(cont_)= rst_BM3("SECC_DESC") 		
		w_USU_NIC(cont_)= rst_BM3("USU_NIC") 	
		w_NOMBRE_USU(cont_)= rst_BM3("USU_NOMBRE") & " " & rst_BM3("USU_APELLIDO")		
		IF  cont_  = 1 THEN
			w_USU_NIC_WW = w_USU_NIC(cont_)
		END IF		
		
		rst_BM3.MOVENEXT
		cont_ = cont_ + 1
	WEND		
	
	contLINEA_ = 1
	Activa_Linea_Resultado =0 
	CALL CREA_HOJA_OBJETOS
	call LLENA_MARCO_HOJA()
	'CALL LLENA_ENCABEZADO()			
	DIM CANTIDAD_REG  
	DIM w_ID_PRUEBA, w_ID_PER_P, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, Imprime_F, w_Nom_Seccion, w_TP_Alerta
	CANTIDAD_REG  =0 
	Imprime_F = 0
	flag = 0 
	FOR A__=1 TO CONT_
		IF 	w_ID_PERFIL(A__) <> "" THEN
			IF w_IMP_SOLA(A__) = 0 THEN
				IF TRIM(w_USU_NIC(A__)) = TRIM(w_USU_NIC_WW) THEN
					w_USU_NIC_WW  = w_USU_NIC(A__)  
							Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
							set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")					
							while not rst_BM3.eof
								CANTIDAD_REG = CANTIDAD_REG +1 
								rst_BM3.MOVENEXT
							WEND
							rst_BM3.MOVEFIRST
							if flag = 0 then 
							CALL LLENA_ENCABEZADO_2(Id_atencion_,w_ID_PERFIL(A__))
							end if 
							flag = flag + 1
							IF contLINEA_ <> 1 THEN
								contLINEA_ = contLINEA_ + 2
								CANTIDAD_REG= CANTIDAD_REG +2
							END IF
							IF w_IMP_NOMBREPERF(A__) =1 THEN
								'contLINEA_ = contLINEA_ + 3
							END IF				
							if Activa_Linea_Resultado =0 then
								contLINEA_ = contLINEA_ + 2	
								cont_ = cont_ + 1									
							end if					
			
							DIM AAAA_ 
							AAAA_ = CANTIDAD_REG + contLINEA_ 
							IF (CANTIDAD_REG + contLINEA_ ) < 50 THEN
								IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
									w_SECC_DESC_WW =  w_SECC_DESC(A__)
									'CALL IMPRIME_TITULO_SECCION (w_SECC_DESC(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 2.5
								END IF
			
								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_NOMBRE_CF(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 2.5
								END IF										
								if Activa_Linea_Resultado =0 then
									call Imprime_Linea_Datos_Resultados(contLINEA_)	
									contLINEA_ = contLINEA_ + 2					
									Activa_Linea_Resultado = 1
								end if	
								while not rst_BM3.eof
									w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
									w_ID_PER_P = rst_BM3("ID_PER") 		
									w_ID_UM = rst_BM3("ID_U_MEDIDA")
									w_UM = rst_BM3("UM_DESC")					 		
									w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
									w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
									w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
									w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
									w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
									w_Nom_Seccion= rst_BM3("SECC_DESC") 	
									w_TP_Alerta = trim(rst_BM3("ATE_RESULTADO_ALT"))
															
									CALL IMPRIME_RESULTADO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta)										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
								WEND
								'IMPRIME METODO

								CALL IMPRIME_METODO_DEBAJO(w_ID_PER_P, contLINEA_)
								CALL IMPRIME_TIPO_MUESTRA_DEBAJO(w_ID_PER_P, contLINEA_)
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)								
																		
								if Imprime_F = 0 then
									'CALL IMPRIME_FIRMA_TECNOLOGO
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_NIC(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								end if
			
							ELSE
								Activa_Linea_Resultado =0
								Imprime_F = 0
								contLINEA_ = 1
			
								CALL AGREGA_NUEVA_HOJA	
								'CALL LLENA_ENCABEZADO()	
								CALL LLENA_ENCABEZADO_2(Id_atencion_,w_ID_PERFIL(A__))
								call LLENA_MARCO_HOJA()															
								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_NOMBRE_CF(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 2.5
								END IF					
								if Activa_Linea_Resultado =0 then
									call Imprime_Linea_Datos_Resultados(contLINEA_)	
									contLINEA_ = contLINEA_ + 2					
									Activa_Linea_Resultado = 1
								end if	
								while not rst_BM3.eof
									w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
									w_ID_PER_P = rst_BM3("ID_PER") 		
									w_ID_UM = rst_BM3("ID_U_MEDIDA")
									w_UM = rst_BM3("UM_DESC")					 		
									w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
									w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
									w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
									w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
									w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
									w_Nom_Seccion= rst_BM3("SECC_DESC") 	
									w_TP_Alerta = rst_BM3("ATE_RESULTADO_ALT") 																
									
									CALL IMPRIME_RESULTADO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta )										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
								WEND
								'IMPRIME METODO
								CALL IMPRIME_METODO_DEBAJO(w_ID_PER_P, contLINEA_)
								CALL IMPRIME_TIPO_MUESTRA_DEBAJO (w_ID_PER_P, contLINEA_)
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)
								
																								
								if Imprime_F = 0 then
									'CALL IMPRIME_FIRMA_TECNOLOGO
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_NIC(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								end if
													
							END IF				
					ELSE
									
								w_USU_NIC_WW  = w_USU_NIC(A__)  					
								Activa_Linea_Resultado =0
								Imprime_F = 0
								contLINEA_ = 1
								
								CALL AGREGA_NUEVA_HOJA									
								'CALL LLENA_ENCABEZADO()	
								CALL LLENA_ENCABEZADO_2(Id_atencion_,w_ID_PERFIL(A__))
								call LLENA_MARCO_HOJA()
								w_SECC_DESC_WW =""															

								IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
									w_SECC_DESC_WW =  w_SECC_DESC(A__)
									'CALL IMPRIME_TITULO_SECCION (w_SECC_DESC(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 2.5
								END IF

								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_NOMBRE_CF(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 2.5
								END IF					
								if Activa_Linea_Resultado =0 then
									call Imprime_Linea_Datos_Resultados(contLINEA_)	
									contLINEA_ = contLINEA_ + 2					
									Activa_Linea_Resultado = 1
								end if	
								set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")													
								while not rst_BM3.eof
									w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
									w_ID_PER_P = rst_BM3("ID_PER") 		
									w_ID_UM = rst_BM3("ID_U_MEDIDA")
									w_UM = rst_BM3("UM_DESC")					 		
									w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
									w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
									w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
									w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
									w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
									w_Nom_Seccion= rst_BM3("SECC_DESC") 	
									w_TP_Alerta = rst_BM3("ATE_RESULTADO_ALT") 																									
									CALL IMPRIME_RESULTADO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta )										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
								WEND
								'IMPRIME METODO
								
								CALL IMPRIME_METODO_DEBAJO(w_ID_PER_P, contLINEA_)
								CALL IMPRIME_TIPO_MUESTRA_DEBAJO (w_ID_PER_P, contLINEA_)
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)
								
								if Imprime_F = 0 then
									'CALL IMPRIME_FIRMA_TECNOLOGO
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_NIC(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								end if																		
					END IF
			ELSE
				IF w_IMP_SOLA(A__) = 1 THEN
					Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
					set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")					
					while not rst_BM3.eof
						CANTIDAD_REG = CANTIDAD_REG +1 
						rst_BM3.MOVENEXT
					WEND
					if CANTIDAD_REG <> 0 then
						set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")					
						'rst_BM3.MOVEFIRST
					end if
					
					IF contLINEA_ <> 1 THEN
						contLINEA_ = contLINEA_ + 2
						CANTIDAD_REG= CANTIDAD_REG +2
					END IF
					IF w_IMP_NOMBREPERF(A__) =1 THEN
					END IF				
					if Activa_Linea_Resultado =0 then
						cont_ = cont_ + 1									
					end if					
					Activa_Linea_Resultado =0					
					contLINEA_ = 1				
					if cint(A__) <> 1 then
						CALL AGREGA_NUEVA_HOJA	
						'CALL LLENA_ENCABEZADO()
							
						call LLENA_MARCO_HOJA()															
					end if
                    CALL LLENA_ENCABEZADO_2(Id_atencion_,w_ID_PERFIL(A__))
					IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
						w_SECC_DESC_WW =  w_SECC_DESC(A__)
						'CALL IMPRIME_TITULO_SECCION(w_SECC_DESC(A__),contLINEA_)					
						contLINEA_ = contLINEA_ + 2.5
					END IF
					
					IF w_IMP_NOMBREPERF(A__) =1 THEN
						CALL IMPRIME_TITULO_NUEVO(w_NOMBRE_CF(A__),contLINEA_)
						contLINEA_ = contLINEA_ + 2.5
					END IF					
					
					if Activa_Linea_Resultado =0 then
						contLINEA_ = contLINEA_ + 2					
						Activa_Linea_Resultado = 1
					end if	
					act_nuevo_firma =false
					while not rst_BM3.eof
						w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
						w_ID_PER_P = rst_BM3("ID_PER") 		
						w_ID_UM = rst_BM3("ID_U_MEDIDA")
						w_UM = rst_BM3("UM_DESC")					 		
						w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
						w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
						w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
						w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
						w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
						w_Nom_Seccion= rst_BM3("SECC_DESC") 	
						w_TP_Alerta = trim(rst_BM3("ATE_RESULTADO_ALT")) 																									
						
						CALL IMPRIME_RESULTADO_NUEVO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta )										
						rst_BM3.MOVENEXT
						cont_ = cont_ + 1
						contLINEA_  =0
						contLINEA_ = contLINEA_ + 1
						act_nuevo_firma =true
					WEND
					call IMPRIME_METODO_DEBAJO2(w_ID_PER_P)
					call IMPRIME_TIPO_MUESTRA_DEBAJO2(w_ID_PER_P)
					if act_nuevo_firma = true then
						if A__ >2 then
							'CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_NIC(A__ - 2))	
							
							CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_NIC(A__ ))	
														
							CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__ - 2))
						else

							CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_NIC(A__ ))							
						end if
					end if					
										
				END IF
			END IF		
		END IF
	NEXT		
	CALL IMPRIME_ULTIMA_LINEA

	'CALL IMPRIME_FIRMA_TECNOLOGO
	CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_NIC(A__ - 2))	
	CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__ - 2))					
	
	CALL Imprime_Hoja(session("N_PAC"))
	
%>
<HTML>
<HEAD>
<TITLE>Laboratorio  .:::Impresion de Resultados:::.</TITLE>
</HEAD>
<BODY>

<script language="JavaScript">
	document.location.href = "<%= "PDF/" + Filename%>" ;
</script>
</BODY>
</HTML>

<%

FUNCTION IMPRIME_ULTIMA_LINEA

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	contLINEA_ = 49
	XX =  10
	YY = 630 - (contLINEA_ * 10)		
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 9
	'Page.Canvas.DrawText "Resultado", Params, Font
END FUNCTION


Function Imprime_Linea_Datos_Resultados(contLINEA_)

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	

	XX =  30
	YY = 630 - (contLINEA_ * 10)		
	Params("x") = XX	
	Params("y") = YY 
	Params("size") = 9
	Page.Canvas.DrawText "Examen", Params, Font

	XX =  365
	YY = 630 - (contLINEA_ * 10)		
	Params("x") = XX	
	Params("y") = YY 
	Params("size") = 9
	Page.Canvas.DrawText "Unidad", Params, Font

	XX =  265
	YY = 630 - (contLINEA_ * 10)		
	Params("x") = XX	
	Params("y") = YY 
	Params("size") = 9
	Page.Canvas.DrawText "Resultado", Params, Font

	XX =  480
	YY = 630 - (contLINEA_ * 10)		
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 9
	Page.Canvas.DrawText "Valores de Referencia", Params, Font


end function


FUNCTION IMPRIME_TITULO(DATO_TITU, NLINEA)

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  (Width_ -  CANT_LEN2)
	YY = 630 - (NLINEA * 11)
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 10
	Page.Canvas.DrawText DATO_TITU, Params, Font

END FUNCTION

FUNCTION IMPRIME_TITULO_NUEVO(DATO_TITU, NLINEA)

	'NLINEA= NLINEA - 2
	NLINEA= NLINEA 
	RUTA_ ="c:\windows\fonts\arialbd.ttf" 											
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  20
	YY = 630 - (NLINEA * 11)
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 12
	Page.Canvas.DrawText DATO_TITU, Params, Font

END FUNCTION


FUNCTION IMPRIME_VALIDADO_POR(DATO_TITU, NLINEA, NOM_VALIDA)
	DIM Datos_COMPLETO

	RUTA_ ="c:\windows\fonts\arial.ttf" 											
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	Datos_COMPLETO = "Examen(es) Validado Por: " &  NOM_VALIDA
	Set Params = Pdf.CreateParam	
	Width_ =  500 / 2	
	XX =  17
	YY = 630 - (NLINEA * 11)
	YY = 80
	
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 9
	'Page.Canvas.DrawText Datos_COMPLETO, Params, Font

END FUNCTION

FUNCTION IMPRIME_METODO_DEBAJO(WID_PERFIL, contLINEA_)
	DIM Datos_COMPLETO
	set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_METODO_NUEVO '"&WID_PERFIL&"' ")													
	BBBC =0
	while not rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	if BBBC>0 then
		rst_BM33.MOVEFIRST
	end if
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 1.5
	w_METODO_NUEVO =""
	while not rst_BM33.eof
		if BBBC_1 =0 then
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "M�todo Anal�tico : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		end if
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION



FUNCTION IMPRIME_TIPO_MUESTRA_DEBAJO(WID_PERFIL, contLINEA_)
	DIM Datos_COMPLETO
	set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&WID_PERFIL&"' ")													
	BBBC =0
	while not rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	if BBBC>0 then
		rst_BM33.MOVEFIRST
	end if
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 0.25
	w_METODO_NUEVO =""
	while not rst_BM33.eof
		if BBBC_1 =0 then
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.05	
		end if
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION



FUNCTION IMPRIME_DERIVADO_DEBAJO(WID_PERFIL, contLINEA_)
	DIM Datos_COMPLETO
	set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_DERIVADOR_NUEVO '"&WID_PERFIL&"' ")													
	BBBC =0
	while not rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	if BBBC>0 then
		rst_BM33.MOVEFIRST
	end if
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 0.5
	w_METODO_NUEVO =""
	while not rst_BM33.eof
		if BBBC_1 =0 then
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("DERI_DESC") 
			Datos_COMPLETO = "Derivado a : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "            " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		end if
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION



FUNCTION IMPRIME_TITULO_SECCION(DATO_TITU, NLINEA)

	RUTA_ ="c:\windows\fonts\arialbd.ttf" 											
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)

	'Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  (Width_ -  CANT_LEN2)
	YY = 630 - (NLINEA * 11)
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 10
	Page.Canvas.DrawText DATO_TITU, Params, Font

END FUNCTION

FUNCTION IMPRIME_RESULTADO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta)
'IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA
	DIM YY
	set rst_BM4 = connBM3.execute("IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA '"&w_ID_PRUEBA&"'")	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	

	YY = 630 - (contLINEA_ * 11)
	while not rst_BM4.eof
		DIM FR_OBJETO_, FR_COLUMNA_, FR_TEXTO_, FR_TAMANO_, LET_DESC_, COLUMNA_, XX, CONCATE_
		
		FR_OBJETO_ =  rst_BM4("FR_OBJETO")
		FR_COLUMNA_ = rst_BM4("FR_COLUMNA")

		FR_TEXTO_ = rst_BM4("FR_TEXTO")
		FR_TAMANO_ = rst_BM4("FR_TAMANO")				
		LET_DESC_ = rst_BM4("LET_DESC")
		COLUMNA_ = Cint(FR_COLUMNA_)
		XX = Cint(rst_BM4("FR_FILA"))
		
		IF FR_OBJETO_ ="Iris_Nombre" THEN
			IF TRIM(FR_TEXTO_) <> ":" THEN
				if Cint(FR_COLUMNA_) < 4500 then
					if Cint(FR_COLUMNA_) < 301 then

						XX = (COLUMNA_/10)
						Params("x") = XX
						contLINEA_ = contLINEA_ + 1.5
						YY = 630 - (contLINEA_ * 11)
						Params("y") = YY
						Params("size") = FR_TAMANO_
						Page.Canvas.DrawText FR_TEXTO_, Params, Font

						'XX = COLUMNA_/10						
						'Params("x") = XX	
						'Params("y") = YY
						'Params("size") = FR_TAMANO_
						'Page.Canvas.DrawText FR_TEXTO_, Params, Font
					
					else
						XX = COLUMNA_/10						
						Params("x") = XX	
						Params("y") = YY
						Params("size") = FR_TAMANO_
						Page.Canvas.DrawText FR_TEXTO_, Params, Font
					end if
				else
					
					XX = (COLUMNA_/10) -135
					Params("x") = XX
					contLINEA_ = contLINEA_ + 1
					YY = 630 - (contLINEA_ * 11)
					Params("y") = YY
					Params("size") = FR_TAMANO_
					Page.Canvas.DrawText FR_TEXTO_, Params, Font
									
				end if
			ELSE
				XX = (COLUMNA_/10)-100					
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
							
			END IF		
		END IF

		IF FR_OBJETO_ ="Iris_Det" THEN
			IF Cint(w_ID_TP_RESUL) = 1 THEN
				XX = (COLUMNA_/10)-80
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
			ELSE
				XX = (COLUMNA_/10)-80						
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font
							
			END IF		
		END IF

		IF FR_OBJETO_ ="Iris_Unidad" THEN
			IF Cint(w_ID_UM) <> 1 THEN
				IF w_UM <> "" THEN
					XX = (COLUMNA_/10)- 80						
					Params("x") = XX	
					Params("y") = YY
					Params("size") = FR_TAMANO_
					Page.Canvas.DrawText w_UM, Params, Font
				END IF		
			END IF
		END IF
			
		IF FR_OBJETO_ ="Iris_Rango" THEN
			IF TRIM(w_Rango_DESDE) <> "" AND TRIM(w_Rango_HASTA) <> "" THEN
				XX = (COLUMNA_/10)- 140														
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				
				if w_TP_Alerta = "A" or w_TP_Alerta = "B" then
					RUTA_ ="c:\windows\fonts\arialbd.ttf" 
					Set Font = Doc.Fonts.LoadFromFile(RUTA_)
					XX = (COLUMNA_/10)- 140														
					Params("x") = 400	
					Params("y") = YY
					Params("size") = FR_TAMANO_
					CONCATE_ = "["& w_TP_Alerta & "]" 
					Page.Canvas.DrawText CONCATE_, Params, Font				
					
					Set Font = Doc.Fonts("Arial")
					XX = (COLUMNA_/10)- 140														
					Params("x") = XX	
					Params("y") = YY
					Params("size") = FR_TAMANO_
													
					'CONCATE_ = "["& w_TP_Alerta & "]" & " " & w_Rango_DESDE & "-" & w_Rango_HASTA
					CONCATE_ =  w_Rango_DESDE & "-" & w_Rango_HASTA				
					Page.Canvas.DrawText CONCATE_, Params, Font
				
				else
					if trim(w_Rango_HASTA) <> "." then
						Set Font = Doc.Fonts("Arial")
						CONCATE_ =  w_Rango_DESDE & "-" & w_Rango_HASTA
						Page.Canvas.DrawText CONCATE_, Params, Font					
					else
						Set Font = Doc.Fonts("Arial")
						CONCATE_ =  w_Rango_DESDE 
						Page.Canvas.DrawText CONCATE_, Params, Font
					end if
				end if

			END IF		
		END IF

	
		rst_BM4.MOVENEXT
	WEND
	
END FUNCTION

Function IMPRIME_FIRMA_TECNOLOGO

	Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/DPEREIRA.BMP" ) )		
	Set Param = Pdf.CreateParam
	Param("x") = 480	
	Param("y") = 130
	Param("ScaleX") = (0.4)
	Param("ScaleY") =(0.4)			
	Page.Canvas.DrawImage Image, Param

END FUNCTION

Function IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USUARIO_2)


	IF  w_USUARIO_2 = "CESPINOZA" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/CESPINOZA.bmp" ) )		
	
		else
	IF  w_USUARIO_2 = "DCABELLO" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/DCABELLO.bmp" ) )		

		else
	IF  w_USUARIO_2 = "PCORTES" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/PCORTES.bmp" ) )		

		else
	IF  w_USUARIO_2 = "PESPINOZA" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/PESPINOZA.bmp" ) )		

		else	
	IF  w_USUARIO_2 = "JDIAZ" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/JDIAZ.bmp" ) )		

		else
			
    IF  w_USUARIO_2 = "RORELLANA" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/RORELLANA.bmp" ) )
		
		else
		
	IF  w_USUARIO_2 = "ASEPULVEDA" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/ASEPULVEDA.bmp" ) )				

		else	
	
	IF  w_USUARIO_2 = "POLAVE" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/POLAVE.bmp" ) )		

		
		else
		
        IF  w_USUARIO_2 = "AGARATE" THEN
		Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/AGARATE.bmp" ) )		
	
		else


        Set Image = Doc.OpenImage(Server.MapPath( "FIRMAS/PCORTES.bmp" ) )		
	end if
    end if
	end if
	end if
	end if
	end if
    end if
	end if
	end if 
		

	
	Set Param = Pdf.CreateParam
	Param("x") = 330
	Param("y") = 48
	Param("ScaleX") = (0.45)
	Param("ScaleY") =(0.45)			
	Page.Canvas.DrawImage Image, Param

END FUNCTION


FUNCTION IMPRIME_RESULTADO_NUEVO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta)
'IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA
	
	set rst_BM4 = connBM3.execute("IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA '"&w_ID_PRUEBA&"'")	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	DIM FR_OBJETO_, FR_COLUMNA_, FR_TEXTO_, FR_TAMANO_, LET_DESC_, COLUMNA_, YY, XX, CONCATE_ , FILA_
	
	'YY = 630 - (contLINEA_ * 11)
	while not rst_BM4.eof
			
		FR_OBJETO_ =  rst_BM4("FR_OBJETO")
		FR_COLUMNA_ = Cint(rst_BM4("FR_COLUMNA"))
		FR_FILA_ = Cint(rst_BM4("FR_FILA"))
		FR_TEXTO_ = rst_BM4("FR_TEXTO")
		FR_TAMANO_ = rst_BM4("FR_TAMANO")				
		LET_DESC_ = rst_BM4("LET_DESC")
		COLUMNA_ = Cint(FR_COLUMNA_)
		FILA_ =  Cint(FR_FILA_) - 1200
		
		IF FR_OBJETO_ ="Iris_Nombre" THEN
			IF TRIM(FR_TEXTO_) <> ":" THEN
				XX = ((COLUMNA_ * 648)/8000)
				YY = (630- ((FILA_ * 630)/8500))						
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
			ELSE
				XX = ((COLUMNA_ * 648)/8000) 
				YY = (630- ((FILA_ * 630)/8500))						
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
							
			END IF		
		END IF

		IF FR_OBJETO_ ="Iris_Titulo" THEN
			IF TRIM(FR_TEXTO_) <> ":" THEN
				XX = ((COLUMNA_ * 648)/8000)
				YY = (630- ((FILA_ * 630)/8500))						
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
			ELSE
				XX = ((COLUMNA_ * 648)/8000) 
				YY = (630- ((FILA_ * 630)/8500))						
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
							
			END IF		
		END IF


		IF FR_OBJETO_ ="Iris_Det" THEN
			IF Cint(w_ID_TP_RESUL) = 1 THEN
				XX = ((COLUMNA_ * 648)/8000)
				YY = (630- ((FILA_ * 630)/8500))						

				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
			ELSE
				XX = ((COLUMNA_ * 648)/8000)
				YY = (630- ((FILA_ * 630)/8500))						

				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font
							
			END IF		
		END IF

		IF FR_OBJETO_ ="Iris_Unidad" THEN
			IF Cint(w_ID_UM) <> 1 THEN
				IF w_UM <> "" THEN
					XX = ((COLUMNA_ * 648)/8000)
					YY = (630- ((FILA_ * 630)/8500))						
					Params("x") = XX	
					Params("y") = YY
					Params("size") = FR_TAMANO_
					'Page.Canvas.DrawText w_UM, Params, Font
					Page.Canvas.DrawText FR_TEXTO_, Params, Font										
				END IF		
			END IF
		END IF
			
		IF FR_OBJETO_ ="Iris_Rango" THEN
			IF TRIM(w_Rango_DESDE) <> "" AND TRIM(w_Rango_HASTA) <> "" THEN
				XX = ((COLUMNA_ * 648)/8000)
				YY = (630- ((FILA_ * 630)/8500))						
				Params("x") = XX	
				Params("y") = YY
				Params("size") = FR_TAMANO_
				
				if w_TP_Alerta = "A" or w_TP_Alerta = "B" then				
					XX = ((COLUMNA_ * 648)/8000)
					YY = (630- ((FILA_ * 630)/8500))						
					Params("x") = XX	
					Params("y") = YY
					Params("size") = FR_TAMANO_				
					CONCATE_ = w_Rango_DESDE & "-" & w_Rango_HASTA
					Page.Canvas.DrawText CONCATE_, Params, Font
					'CONCATE_ = "["& w_TP_Alerta & "]" & " " & w_Rango_DESDE & "-" & w_Rango_HASTA
					
					RUTA_ ="c:\windows\fonts\arialbd.ttf" 
					Set Font = Doc.Fonts.LoadFromFile(RUTA_)
					XX = ((COLUMNA_ * 648)/8000) -13
					YY = (630- ((FILA_ * 630)/8500))						
					Params("x") = XX	
					Params("y") = YY
					Params("size") = FR_TAMANO_				
					CONCATE_ = "["& w_TP_Alerta & "]" 
					Page.Canvas.DrawText CONCATE_, Params, Font										
					
				else
					CONCATE_ = w_Rango_DESDE & "-" & w_Rango_HASTA
					Page.Canvas.DrawText CONCATE_, Params, Font
				end if
				
				'Page.Canvas.DrawText CONCATE_, Params, Font
			END IF		
		END IF

	
		rst_BM4.MOVENEXT
	WEND
	
END FUNCTION

FUNCTION CREA_HOJA_OBJETOS
	Set Pdf = Server.CreateObject("Persits.Pdf")
	Set Doc = Pdf.CreateDocument

	Width =  612
	Height = 792
	Set Page = Doc.Pages.Add( Width, Height )	

END FUNCTION

function LLENA_MARCO_HOJA

	Set Image = Doc.OpenImage(Server.MapPath( "Firmas/no_foto.jpg" ) )		
	Set Param = Pdf.CreateParam
	Param("x") = 10	
	Param("y") = 715
	Param("ScaleX") = (0.075)
	Param("ScaleY") =(0.06)			
	Page.Canvas.DrawImage Image, Param
	
	Set Image = Doc.OpenImage(Server.MapPath( "img/logo_acreditado.jpg" ) )		
	Set Param = Pdf.CreateParam
	Param("x") = 500
	Param("y") = 715
	Param("ScaleX") = (0.3)
	Param("ScaleY") =(0.3)			
	Page.Canvas.DrawImage Image, Param

	Set Font = Doc.Fonts("Arial Black")
	Set Params = Pdf.CreateParam	
	Params("x") = 180
	Params("y") = 780
	Params("size") = 16	
	Page.Canvas.DrawText "Laboratorio Clinico Alem�n Ltda.", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 180	
	Params("y") = 765
	Params("size") = 14
	Page.Canvas.DrawText "Direcci�n: Manuel Montt 378, Curic�", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 180	
	Params("y") = 750
	Params("size") = 13	
	Page.Canvas.DrawText "Telfono: (075) 2323749", Params, Font

	'Set Font = Doc.Fonts("Arial")
	'Set Params = Pdf.CreateParam	
	'Params("x") = 145	
	'Params("y") = 745
	'Params("size") = 13	
	'Page.Canvas.DrawText "Sitio Web : www.diagnotest.cl", Params, Font
	

	
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 718
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 645
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font
	
	RUTA_ ="c:\windows\fonts\arialbd.ttf" 
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 80
	Params("size") = 8	
	Page.Canvas.DrawText "   [A] = Alto ", Params, Font


	
	RUTA_ ="c:\windows\fonts\arialbd.ttf" 
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 70
	Params("size") = 8	
	Page.Canvas.DrawText "   [B] = Bajo ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 60
	Params("size") = 8	
	Page.Canvas.DrawText "   ESTE INFORME NO CONSTITUYE DIAGNOSTICO, CONSULTE A SU MEDICO", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 50
	Params("size") = 8	
	Page.Canvas.DrawText "   LABORATORIO ADSCRITO AL PROGRAMA DE EVALUACION EXTERNA DE CALIDAD DEL I.S.P. DE CHILE", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 40
	Params("size") = 7	
	Page.Canvas.DrawText "   SUCURSALES: YUNGAY 475 LOCAL N1 CURICO - FONO 2336060", Params, Font

	
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 50	
	Params("y") = 30
	Params("size") = 7	
	Page.Canvas.DrawText "   YERBAS BUENAS 1205 MOLINA - FONO 2492425", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 50	
	Params("y") = 23
	Params("size") = 7	
	Page.Canvas.DrawText "   PRAT 116 LOCAL N1 CURICO - FONO 2320130 ", Params, Font


	Width =  612
	Height = 792
End function

FUNCTION IMPRIME_TIPO_MUESTRA_DEBAJO2(WID_PERFIL)
	DIM Datos_COMPLETO
	set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&WID_PERFIL&"' ")													
	BBBC =0
	while not rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	if BBBC>0 then
		rst_BM33.MOVEFIRST
	end if
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 0.25
	w_METODO_NUEVO =""
	while not rst_BM33.eof
		if BBBC_1 =0 then
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  50
			YY = 190
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  50
			YY = 190
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.05	
		end if
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION


FUNCTION IMPRIME_METODO_DEBAJO2(WID_PERFIL)
	DIM Datos_COMPLETO
	set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_METODO_NUEVO '"&WID_PERFIL&"' ")													
	BBBC =0
	while not rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	if BBBC>0 then
		rst_BM33.MOVEFIRST
	end if
	BBBC_1 =0
	contLINEA_ = 10000
	w_METODO_NUEVO =""
	while not rst_BM33.eof
		if BBBC_1 =0 then
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "M�todo Anal�tico : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = 50
			Params("y") = 200
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  31
			YY = 630 - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		end if
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION


function LLENA_ENCABEZADO
	dim g_nombre,g_fecha, g_rut, g_numero, g_fnac, g_Proce, g_edad, g_sexo, g_Prevision, g_usuario_, g_Medico_
	
	Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
	
 	set rst_BM5 = connBM3.execute("IRISLABWEB_BUSCA_ATENCION2 '"&Id_atencion_&"' ")	
	if not rst_BM5.eof then
	
	    archivo = rst_BM5("PAC_NOMBRE") & rst_BM5("PAC_APELLIDO") & rst_BM5("ATE_FECHA")
		session("N_PAC") = replace(archivo," ","")	
		g_nombre= rst_BM5("PAC_NOMBRE") & " " & rst_BM5("PAC_APELLIDO")	
		g_fecha = rst_BM5("ATE_FECHA")
		g_rut = rst_BM5("PAC_RUT")
		g_numero = rst_BM5("ATE_NUM")
		g_fnac = rst_BM5("PAC_FNAC") 
		g_Proce = rst_BM5("PROC_DESC")
		g_edad = rst_BM5("ATE_A�O") & "a "& rst_BM5("ATE_MES") & "m "& rst_BM5("ATE_DIA") & "d"
		g_sexo = rst_BM5("SEXO_DESC")
		g_Prevision = rst_BM5("PREVE_DESC")
		g_usuario_ = rst_BM5("USU_NIC")		
		g_Medico_ = rst_BM5("DOC_NOMBRE") & " " &  rst_BM5("DOC_APELLIDO")
		g_programa = rst_BM5("PROGRA_DESC")
				
	end if	

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText "Nombre ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font
	'g_nombre

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText g_nombre, Params, Font
	

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText "N� Atenci�n", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_numero, Params, Font



	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText "M�dico ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText g_Medico_, Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText "Procedencia", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText g_Proce, Params, Font


	'Segunda columna	

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText "Rut", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText g_rut, Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 160	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText "Sexo", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 180	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 190	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_sexo, Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam
	Params("x") = 250	
	Params("y") = 692		
	'Params("x") = 250	
	'Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText "Edad", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 280	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 290	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_edad & "", Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam
	Params("x") = 400	
	Params("y") = 692		
	Params("size") = 10	
	Page.Canvas.DrawText "Programa", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_programa & "", Params, Font



	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText "Fecha Ingreso", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText g_fecha , Params, Font



	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText "Fecha Impreso", Params, Font

	'IRIS_HORA_SERVIDOR
	set rst_BM_HORA = connBM3.execute("IRIS_HORA_SERVIDOR")	
	if not rst_BM_HORA.eof then
		fecha =  MID(rst_BM_HORA("DATO"),1,19)
		tiempo =  ""
	END IF
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 666
	Params("size") = 10	
	'tiempo = Time()
	'fecha = Date()
	Page.Canvas.DrawText " :  " & fecha & " " & tiempo, Params, Font	

	
end function

function LLENA_ENCABEZADO_2(id_atencion,id_perfil)
	dim g_nombre,g_fecha, g_rut, g_numero, g_fnac, g_Proce, g_edad, g_sexo, g_Prevision, g_usuario_, g_Medico_
	
	Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
	
 	set rst_BM5 = connBM3.execute("IRISLABWEB_BUSCA_DATOS_ENCABEZADO2 '"&id_atencion&"','"&id_perfil&"' ")	
	
	if not rst_BM5.eof then
	     
		archivo = rst_BM5("PAC_NOMBRE") & rst_BM5("PAC_APELLIDO") & rst_BM5("ATE_FECHA")
		session("N_PAC") = replace(archivo," ","")	
		g_nombre= rst_BM5("PAC_NOMBRE") & " " & rst_BM5("PAC_APELLIDO")	
		g_fecha = rst_BM5("ATE_FECHA")
		g_rut = rst_BM5("PAC_RUT")
		g_numero = rst_BM5("ATE_NUM")
		g_fnac = rst_BM5("PAC_FNAC") 
		g_Proce = rst_BM5("PROC_DESC")
		g_edad = rst_BM5("ATE_A�O") & "a "& rst_BM5("ATE_MES") & "m "& rst_BM5("ATE_DIA") & "d"
		g_sexo = rst_BM5("SEXO_DESC")
		g_f_TM = rst_BM5("ATE_FEC_TM")
		g_f_RECEP = rst_BM5("ATE_FEC_RECEP")		
		g_Medico_ = rst_BM5("DOC_NOMBRE") & " " &  rst_BM5("DOC_APELLIDO")
	'	g_programa = rst_BM5("PROGRA_DESC")
				
	end if	

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText "Nombre ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font
	'g_nombre

	Set Font = Doc.Fonts("Arial Black")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText g_nombre, Params, Font
	

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText "Solicitante ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText g_Medico_, Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText "Lugar TM.", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText g_Proce, Params, Font


	'Segunda columna	
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 705
	Params("size") = 10	
	Page.Canvas.DrawText "N� Atenci�n", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 705 
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial Black")
	Set Params = Pdf.CreateParam	
	Params("x") = 480 
	Params("y") = 705 
	Params("size") = 10	
	Page.Canvas.DrawText g_numero, Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 25	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText "Rut", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial Black")
	Set Params = Pdf.CreateParam	
	Params("x") = 90		
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_rut, Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 170	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText "Sexo", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 190	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 200	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_sexo, Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam
	Params("x") = 260	
	Params("y") = 692		
	'Params("x") = 250	
	'Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText "Edad", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 290	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 300	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_edad & "", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText "F.Ingreso", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 692
	Params("size") = 10	
	Page.Canvas.DrawText g_fecha , Params, Font
	
	
	if isnull(g_f_TM) then
	else
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText "Fecha TM", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 679
	Params("size") = 10	
	Page.Canvas.DrawText g_f_TM , Params, Font
	end if


    if isnull(g_f_RECEP) then
	
	else 
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText "Fecha Recep", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 666
	Params("size") = 10	
	Page.Canvas.DrawText g_f_RECEP , Params, Font
	'Page.Canvas.DrawText g_fecha , Params, Font
	end if 

	
end function

Function Imprime_Hoja(N_PAC)
	DIM TEXTO_PDF
	DIM TEXTO_PDF2
	DIM TEXTO_PDF3
	DIM TEXTO_PDF4
	DIM fecha
	DIM tiempo 
	
	DIM xg_caracter
	DIM xg_caracter2
	DIM xg_caracter3
	DIM xg_caracter4
	DIM xg_newpassword 
	DIM j

	dim Actual 
	dim min_v
	dim seg_v

	TEXTO_PDF = Id_atencion_
	TEXTO_PDF =session("ID_ATEN")


	if trim(TEXTO_PDF) ="2011062200292077" then
		xg_caracter2 = "Resultado"+TEXTO_PDF+".PDF"
	else
	Actual = Now() 
	tiempo = trim(cint(Minute(Actual) & Second(Actual)))
	min_v = trim(cint(minute(Actual)))
	seg_v = trim(cint(Second(Actual)))
	fecha = FormatDateTime(Actual, 2) 

	TEXTO_PDF = Id_atencion_
	TEXTO_PDF =session("ID_ATEN")

	xg_newpassword = ""
	for j=1 to len(trim(TEXTO_PDF))
		xg_caracter = mid(TEXTO_PDF,j,1)
		xg_caracter = xg_caracter + asc(xg_caracter) 
	next
	xg_caracter = Right("00" & Hex(xg_caracter Mod 256), 2)


	xg_newpassword = ""
	for j=1 to len(trim(tiempo))
		xg_caracter3 = mid(tiempo,j,1)
		xg_caracter3 = xg_caracter3 + asc(xg_caracter3) 
	next
	xg_caracter3 = Right("00" & Hex(xg_caracter3 Mod 256), 2)

	'xg_caracter2 = md5("Resultado"+TEXTO_PDF+N_PAC+xg_caracter+min_v+seg_v+tiempo+xg_caracter3) +".PDF"
    xg_caracter2 = "Resultado"+".PDF"
	end if

	Filename = Doc.Save( Server.MapPath("PDF/" & xg_caracter2), False )
end function

FUNCTION AGREGA_NUEVA_HOJA
	Width =  612
	Height = 792
	Set Page = Doc.Pages.Add( Width, Height )	
END FUNCTION

%>