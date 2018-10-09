export enum InheritanceType {
    None = 'None',
    NoInheritance = 'NoInheritance',          // No hay herencia
    Inherited = 'Inherited',              // La entidad esta heredandose de otra aplicacion padre
    PartiallyOverridden = 'PartiallyOverridden',    // La entidad esta heredandose de otra aplicacion padre y la modificandola parcialmente
    Overridden = 'Overridden'              // La entidad esta sobreescribiendo completamente la entidad que existia en el padre
}