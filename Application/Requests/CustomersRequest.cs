﻿namespace Application.Requests
{
    public class CustomersRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string AreaName { get; set; }
        public string CityName { get; set; }
    }
}
