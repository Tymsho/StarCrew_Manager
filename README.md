# 🚀 Star Crew Manager

**Star Crew Manager** es una aplicación de escritorio Windows Forms construida en **C# y .NET**, siguiendo el patrón de arquitectura **MVC (Model-View-Controller)** y conectada a una base de datos **SQL Server**.

Esta aplicación actúa como un gestor/simulador de la tripulación de una nave espacial. Permite crear tripulantes con distintos roles, asignarlos a misiones y simular sus resultados. Si los requisitos de una misión se cumplen, los tripulantes asignados ganan experiencia y suben de nivel, habilitándolos para misiones más complejas.

---

## ⚙️ Antes de ejecutar

1. Crea una base de datos en **SQL Server** utilizando el script de query.txt incluido en los archivos del repositorio.
2. Abre el archivo `Modelo.cs` dentro del proyecto.
3. Busca la clase `Conexion` y modifica la propiedad `Local` para configurar correctamente tu cadena de conexión con la base de datos local.
4. Ir a la carpeta `StarCrewMVC`, ubicar el archivo `FormMain.resx`, hacer clic derecho y seleccionar `Propiedades`, aqui tildar la opcion que dice `Desbloquear`, aplicar cambios y aceptar (esto se debe a que windows bloquea el icono del programa al provenir de la web y considerarlo potencialmente inseguro).
5. Guarda los cambios y compila el proyecto. ¡Listo para usar!

---

## 🧭 Menú principal

Al ejecutar la aplicación, se abre una ventana principal con el nombre del sistema y 4 botones para navegar por las secciones:

- **Tripulantes**
- **Misiones**
- **Historial**
- **Salir**

---

## 👨‍🚀 Tripulantes

Esta sección permite crear y gestionar tripulantes:

- Introduce el nombre del tripulante en la caja de texto inferior izquierda.
- Selecciona un rol desde el menú desplegable.
- Haz clic en **Agregar** para registrar un nuevo tripulante.
- Los tripulantes creados se listarán en la tabla superior.
- Los tripulantes creados pueden ser actualizados.
- Los tripulantes creados pueden ser eliminados solo si aun no se le ha asignado ninguna mision (al contratar su servicio el sindicato no te permite eliminarlos).

---

## 🛰️ Misiones

Aquí puedes gestionar y asignar misiones:

- Se muestra una lista con todas las misiones: título, tipo, dificultad y requisitos.
- Cada misión tiene un botón **Seleccionar** para iniciar su asignación.
- En la parte inferior encontrarás una tabla con tripulantes disponibles.
- Puedes asignarlos a la misión mediante el botón **Asignar**.
- Una vez seleccionados, haz clic en **Asignar Misión** para confirmar, o en **Borrar** para reiniciar la asignación.

📌 **Importante:**  
Una misión que ya tiene asignaciones pendientes **no puede ser reasignada** con una tripulación diferente. Cualquier nuevo tripulante asignado se sumará a la misma asignación existente.

---

## 📜 Historial

Esta sección te permite:

- Ver las **misiones activas** y sus asignaciones en la tabla superior.
- Seleccionar una misión activa con el botón **Seleccionar**.
- Finalizar una misión con **Finalizar Misión**. Se validará si la asignación cumple los requisitos y se marcará como **Exitosa** o **Fallida**.
- Abajo se muestra un historial de misiones finalizadas con su **hora de ejecución** y **resultado**.

---

## ❌ Salir

El botón **Salir** cierra la aplicación.

---

### 🛠️ Tecnologías utilizadas

- C#
- .NET Framework
- WinForms
- SQL Server
- Arquitectura MVC


