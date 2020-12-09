Table persona {
  rut_persona varchar2 [pk]
  nombre varchar2
  codigo_persona int [not null]
  direccion varchar2
  telefono int
  correo varchar2
  id_comuna varchar2
  id_tipo_persona int
 
  }
 
 
Table comuna {
  id_comuna varchar2 [pk]
  nombre_comuna varchar2

  }
 
Table medico {
  id_medico varchar2 [pk]
  id_especialidad varchar2
  id_tipo_persona int
  id_ficha int

  }
 
Table tipo_persona {
  id_tipo_persona varchar2 [pk]
  nombre_tipo_persona varchar2

  }
 
Table recepcionista {
  id_recepcionista varchar2 [pk]
  id_area_trabajo varchar2
  id_tipo_persona int
  id_registro int
 

  }
 
Table cliente {
  id_cliente varchar2 [pk]
  codigo_personal varchar2
  comentario int
  id_ficha int
  id_tipo_persona int

  }
 
 
Table administrador {
  id_administrador varchar2 [pk]
  id_tipo_persona int
  }
 
Table ficha {
  id_ficha int[pk]
  id_detalle_ficha int
  id_registro int
  }
 
Table detalle_ficha_paciente {
  id_detalle_ficha int[pk]
  detalle text
  id_enfermedad int
  }
 
Table enfermedad {
  id_enfermedad int[pk]
  nombre_enfermedad varchar2
  tratamiento text
  informacion text
  }
 
 



Ref: "comuna"."id_comuna" < "persona"."id_comuna"

Ref: "persona"."id_tipo_persona" < "tipo_persona"."id_tipo_persona"

Ref: "tipo_persona"."id_tipo_persona" < "medico"."id_tipo_persona"


Ref: "ficha"."id_ficha" < "cliente"."id_ficha"

Ref: "ficha"."id_detalle_ficha" < "detalle_ficha_paciente"."id_detalle_ficha"

Ref: "ficha"."id_ficha" < "medico"."id_ficha"

Ref: "enfermedad"."id_enfermedad" < "detalle_ficha_paciente"."id_enfermedad"

Ref: "recepcionista"."id_registro" < "ficha"."id_registro"


Ref: "tipo_persona"."id_tipo_persona" < "administrador"."id_tipo_persona"

Ref: "cliente"."id_tipo_persona" < "tipo_persona"."id_tipo_persona"

Ref: "recepcionista"."id_tipo_persona" < "tipo_persona"."id_tipo_persona"

