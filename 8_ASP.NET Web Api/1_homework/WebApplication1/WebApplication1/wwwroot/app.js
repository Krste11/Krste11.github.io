const apiBaseUrl = '/api/users';
const results = document.getElementById('results');

async function getAllUsers()
{
    try
    {
        const res = await fetch(apiBaseUrl);
        const data = await res.json();

        results.className = "alert alert-secondary";
        results.innerHTML = `<strong>All Users:</strong><br>${data.join('<br>')}`;
    } catch (err)
    {
        console.error(err);
    }
}

async function getUserById()
{
    const id = document.getElementById('userId').value;
    try
    {
        const res = await fetch(`${apiBaseUrl}/${id}`);

        if (!res.ok)
        {
            throw new Error(await res.text());
        }

        const user = await res.text();
        results.className = "alert alert-success";
        results.innerHTML = `<strong>User:</strong> ${user}`;
    } catch (err)
    {
        results.className = "alert alert-danger";
        results.innerHTML = `<strong>Error:</strong> ${err.message}`;
    }
}
