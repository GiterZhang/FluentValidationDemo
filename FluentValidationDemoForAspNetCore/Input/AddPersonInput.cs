namespace FluentValidationDemoForAspNetCore.Input
{
    /// <summary>
    /// 添加人入参
    /// </summary>
    public class AddPersonInput
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Province { get; set; }

        public string Address { get; set; }

        public string IDCard { get; set; }

        public ManType ManType { get; set; }
    }
}
