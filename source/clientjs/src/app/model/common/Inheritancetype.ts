export enum InheritanceType {
    None = 0,
    NoInheritance = 1,          // No hay herencia
    Inherited = 2,              // La entidad esta heredandose de otra aplicacion padre
    PartiallyOverridden = 3,    // La entidad esta heredandose de otra aplicacion padre y la modificandola parcialmente
    Overridden = 4              // La entidad esta sobreescribiendo completamente la entidad que existia en el padre
}