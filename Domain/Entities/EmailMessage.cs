namespace Domain.Entities;

public sealed class EmailMessage
{
    public required string Email { get; set; }
    public required string Subject { get; set; }
    public required string Message { get; set; }

    public static EmailMessage EmailConfirmationMessage(string clientEmail, string confirmationLink)
    {
        return new EmailMessage()
        {
            Email = clientEmail,
            Subject = "Email confirmation",
            Message = $@"
            <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; }}
                        a {{ text-decoration: none; }}
                        .content {{ padding: 20px; }}
                        .button {{ background-color: #4CAF50; color: white; padding: 10px 20px; text-align: center; text-decoration: none; display: inline-block; border-radius: 5px; }}
                    </style>
                </head>
                <body>
                    <div class='content'>
                        <h1>Welcome!</h1>
                        <p>Thank you for registering. Please confirm your email by clicking the button below:</p>
                        <a href='{confirmationLink}' class='button'>Confirm Email</a>
                    </div>
                </body>
            </html>
            "
        };
    }

    public static EmailMessage ForgotPasswordMessage(
        string clientEmail,
        string confirmationCode,
        string clientName = "client"
    )
    {
        return new EmailMessage()
        {
            Email = clientEmail,
            Subject = "Password reset confirmation",
            Message = $@"
            <!DOCTYPE html>
            <html>
                <head>
                    <style>
                        body {{ font-family: Arial,sans - serif; line-height: 1.6; background-color: #F4F4F4; padding: 20px; text-align: center; }}
                        .container {{ background-color: #FFFFFF; padding: 20px; border-radius: 10px; box-shadow: 0 2px 4px rgba(0,0,0,0.1); max-width: 600px; margin: 0 auto; }}
                        .header {{ background - color: #007BFF; color: #FFFFFF; padding: 10px 0; border-radius: 10px 10px 0 0; }}
                        .header h1 {{ margin: 0; }}
                        .content {{ padding: 20px; }}
                        .button {{ background-color: #007BFF; color: #FFFFFF; padding: 10px 20px; text-decoration: none; border-radius: 5px; display: inline-block; }}
                        .footer {{ margin-top: 20px; font - size: 0.8em; color: #777777; }}
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Password Reset</h1>
                        </div>
                        <div class='content'>
                            <p>Hi {char.ToUpper(clientName[0]) + clientName.Substring(1)},</p>
                            <p>You requested to reset your password. Your confirmation code is:</p>
                            <p>{confirmationCode}</p>
                            <p>If you did not request a password reset, please ignore this email or contact support if you have questions.</p>
                            <p>Thanks,<br>The Education Portal Team </p>
                        </div>
                    </div>
                </body>
            </html>
            "
        };
    }
}
