export const variables = {
    machineStatus : null
}

/**
 * 
 * @param {String} filePath - The file path for the particular JSON file
 * @returns {Object} - The object model in the JSON file
 */
export async function fetchData(filePath) {
    const data = await fetch(filePath)
    return await data.json()
}