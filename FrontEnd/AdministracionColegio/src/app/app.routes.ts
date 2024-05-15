import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AlumnosComponent } from './pages/alumnos/alumnos.component';
import { ProfesoresComponent } from './pages/profesores/profesores.component';
import { GradosComponent } from './pages/grados/grados.component';
import { AlumnosGradosComponent } from './pages/alumnos-grados/alumnos-grados.component';
import { AlumnoCreateComponent } from './pages/alumnos/alumno-create/alumno-create.component';
import { AlumnoReadComponent } from './pages/alumnos/alumno-read/alumno-read.component';
import { AlumnoUpdateComponent } from './pages/alumnos/alumno-update/alumno-update.component';
import { AlumnoDeleteComponent } from './pages/alumnos/alumno-delete/alumno-delete.component';
import { ProfesorCreateComponent } from './pages/profesores/profesor-create/profesor-create.component';
import { ProfesorReadComponent } from './pages/profesores/profesor-read/profesor-read.component';
import { ProfesorUpdateComponent } from './pages/profesores/profesor-update/profesor-update.component';
import { ProfesorDeleteComponent } from './pages/profesores/profesor-delete/profesor-delete.component';
import { GradoCreateComponent } from './pages/grados/grado-create/grado-create.component';
import { GradoReadComponent } from './pages/grados/grado-read/grado-read.component';
import { GradoUpdateComponent } from './pages/grados/grado-update/grado-update.component';
import { GradoDeleteComponent } from './pages/grados/grado-delete/grado-delete.component';
import { AlumnoGradoCreateComponent } from './pages/alumnos-grados/alumno-grado-create/alumno-grado-create.component';
import { AlumnoGradoReadComponent } from './pages/alumnos-grados/alumno-grado-read/alumno-grado-read.component';
import { AlumnoGradoUpdateComponent } from './pages/alumnos-grados/alumno-grado-update/alumno-grado-update.component';
import { AlumnoGradoDeleteComponent } from './pages/alumnos-grados/alumno-grado-delete/alumno-grado-delete.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "alumnos",
        component: AlumnosComponent,
        children: [
            {
                path: "alumno-create",
                component: AlumnoCreateComponent
            },
            {
                path: "alumno-read",
                component: AlumnoReadComponent
            },
            {
                path: "alumno-update",
                component: AlumnoUpdateComponent
            },
            {
                path: "alumno-delete",
                component: AlumnoDeleteComponent
            }
        ]
    },
    {
        path: "profesores",
        component: ProfesoresComponent,
        children: [
            {
                path: "profesor-create",
                component: ProfesorCreateComponent
            },
            {
                path: "profesor-read",
                component: ProfesorReadComponent
            },
            {
                path: "profesor-update",
                component: ProfesorUpdateComponent
            },
            {
                path: "profesor-delete",
                component: ProfesorDeleteComponent
            }
        ]
    },
    {
        path: "grados",
        component: GradosComponent,
        children: [
            {
                path: "grado-create",
                component: GradoCreateComponent
            },
            {
                path: "grado-read",
                component: GradoReadComponent
            },
            {
                path: "grado-update",
                component: GradoUpdateComponent
            },
            {
                path: "grado-delete",
                component: GradoDeleteComponent
            }
        ]
    },
    {
        path: "alumnos-grados",
        component: AlumnosGradosComponent,
        children: [
            {
                path: "alumno-grado-create",
                component: AlumnoGradoCreateComponent
            },
            {
                path: "alumno-grado-read",
                component: AlumnoGradoReadComponent
            },
            {
                path: "alumno-grado-update",
                component: AlumnoGradoUpdateComponent
            },
            {
                path: "alumno-grado-delete",
                component: AlumnoGradoDeleteComponent
            }
        ]
    }
];
