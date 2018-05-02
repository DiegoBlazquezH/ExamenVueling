function getContainerId()
{
    $regexContainerRedis = [regex]'([^\s]*)\s*redis'
    $containerRedis = docker ps -a
    $containerRedis = $regexContainerRedis.Match($containerRedis)
    if($containerRedis.Groups[1].value)
    {
        $idContainer = ($containerRedis.Groups[1].value)
        return $idContainer
    }
    else
    {
        return ""
    }
}

function getImageId()
{
    $regexImageRedis = [regex]'redis\s*latest\s*([^\s]*)'
    $idImage = docker images -a
    $idImage = $regexImageRedis.Match($idImage)
    if($idImage.Groups[1].value)
    {
        $idImage = ($idImage.Groups[1].value)
        return $idImage
    }
    else
    {
        return ""
    }
}
function runRedis()
{
    docker run -p 6379:6379 -d redis
}

# Sacamos el Id del contenedor y el Id de la imagen
$idContainer = getContainerId
$idImage = getImageId

if($idContainer)
{
    Write-Host "El contenedor ya existe con ID" $idContainer ", lo arrancamos"
    docker start $idContainer
    Write-Host "Se ha arrancado el contenedor Redis con ID" $idContainer
}
else 
{
    if($idImage)    
    {
        Write-Host "El contenedor no existe, pero la imagen Redis ya existe, con ID" $idImage
        Write-Host "Creando contenedor Docker de Redis"
        runRedis
        $idContainer = getContainerId
        if($idContainer)
        {
            Write-Host "Se ha creado y arrancado el contenedor Redis con ID" $idContainer
        }
        else
        {
            Write-Host "Error al crear el contenedor. Abortando"
        }
    }
    else
    {
        Write-Host "Ni el contenedor ni la imagen Redis existen"
        Write-Host "Descargando imagen de Redis"
        docker pull redis
        $idImage = getImageId
        if($idImage)    
        {
            Write-Host "Imagen Redis descargada con ID" $idImage
            Write-Host "Creando contenedor Docker de Redis"
            runRedis
            $idContainer = getContainerId
            if($idContainer)
            {
                Write-Host "Se ha creado y arrancado el contenedor Redis con ID" $idContainer
            }
            else
            {
                Write-Host "Error al crear el contenedor. Abortando"
            }
        }
        else
        {
            Write-Host "Error al descargar la imagen Redis. Abortando"
        }
    }
}

Read-Host 'Pulsa Enter para continuar'