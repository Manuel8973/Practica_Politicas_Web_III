# Políticas de Autorización por Género

Este proyecto implementa políticas de autorización basadas en el género del usuario.

## Configuración

### Modelo ApplicationUser
El modelo `ApplicationUser` incluye un campo `genero` con las siguientes constantes:
- `MASCULINO = "M"`
- `FEMENINO = "F"`
- `OTRO = "O"`
- `GENERO_X = "X"`
- `GENERO_Y = "Y"`

### Políticas Disponibles

1. **SoloMasculino**: Permite acceso únicamente a usuarios con género masculino (M)
2. **SoloFemenino**: Permite acceso únicamente a usuarios con género femenino (F)
3. **MasculinoOFemenino**: Permite acceso a usuarios con género binario (M o F)
4. **ExcluyeMasculino**: Permite acceso a todos los géneros excepto masculino

## Uso en Controladores

```csharp
[Authorize(Policy = "SoloMasculino")]
public IActionResult SeccionMasculina()
{
    // Solo usuarios masculinos pueden acceder
    return View();
}

[Authorize(Policy = "SoloFemenino")]
public IActionResult SeccionFemenina()
{
    // Solo usuarias femeninas pueden acceder
    return View();
}
```

## Uso en Vistas (Razor)

```html
@if (User.HasClaim("genero", ApplicationUser.MASCULINO))
{
    <p>Contenido para usuarios masculinos</p>
}

@if (User.HasClaim("genero", ApplicationUser.FEMENINO))
{
    <p>Contenido para usuarias femeninas</p>
}
```

## Ejemplos de URLs

- `/Home/SeccionMasculina` - Solo para usuarios masculinos
- `/Home/SeccionFemenina` - Solo para usuarias femeninas
- `/Home/SeccionBinaria` - Para usuarios con género binario
- `/Home/SeccionNoMasculina` - Excluye usuarios masculinos

## Notas Técnicas

- Los claims de género se agregan automáticamente al iniciar sesión
- Las políticas verifican el claim "genero" del usuario autenticado
- Si un usuario no tiene género definido, se asigna "O" (Otro) por defecto
- Las políticas requieren que el usuario esté autenticado