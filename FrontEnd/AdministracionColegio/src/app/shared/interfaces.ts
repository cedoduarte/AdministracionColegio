export interface ICreateAlumnoCommand {
    nombre: string;
    apellidos: string;
    genero: string;
    fechaNacimiento: string;
}

export interface IUpdateAlumnoCommand {
    id: number;
    nombre: string;
    apellidos: string;
    genero: string;
    fechaNacimiento: string;
}

export interface IAlumnoViewModel {
    id: number;
    nombre: string;
    apellidos: string;
    genero: string;
    fechaNacimiento: string;
}

export interface ICreateProfesorCommand {
    nombre: string;
    apellidos: string;
    genero: string;
}

export interface IUpdateProfesorCommand {
    id: number;
    nombre: string;
    apellidos: string;
    genero: string;
}

export interface IProfesorViewModel {
    id: number;
    nombre: string;
    apellidos: string;
    genero: string;
}

export interface ICreateGradoCommand {
    nombre: string;
    profesorId: number;
}

export interface IUpdateGradoCommand {
    id: number;
    nombre: string;
    profesorId: number;
}

export interface IGradoViewModel {
    id: number;
    nombre: string;
    profesorId: number;
    profesorNombre: string;
}

export interface ICreateAlumnoGradoCommand {
    alumnoId: number;
    gradoId: number;
    seccion: string;
}

export interface IUpdateAlumnoGradoCommand {
    id: number;
    alumnoId: number;
    gradoId: number;
    seccion: string;
}

export interface IAlumnoGradoViewModel {
    id: number;
    alumnoId: number;
    gradoId: number;
    alumnoNombre: string;
    gradoNombre: string;
    seccion: string;
}