
float horizontalInput = Input.GetAxis("Horizontal");
float verticalInput = Input.GetAxis("Vertical");

if (verticalInput >= -15)
{
    // position is >= -14
    transform.position = new Vector3(-3, 5.75f, 0);
    transform.Translate(Vector3.down * (Time.time / _speed));
}